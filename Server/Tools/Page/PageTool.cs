using System.Text.Json;
using ModelContextProtocol.Protocol;
using ModelContextProtocol.Server;
using Server.Errors;

namespace Server.Tools.Page;

public readonly struct PageErrorContext : IErrorContext
{
    public static (string, string?) FromStatusCode(ErrorResponseObject model)
    {
        return model.HttpCode switch
        {
            400 => Handle400(model),
            404 => ("The requested title or revision was not found", null),
            301 or 307 => ("Wikipedia was sending a redirect", null),
            _ => throw new NotSupportedException(
                $"Handling error code {model.HttpCode} for page tool is not supported.")
        };
    }

    private static (string, string?) Handle400(ErrorResponseObject model)
    {
        if (!model.MessageTranslation.TryGetValue("en", out var message))
        {
            return ("Bad request for some reason", null);
        }
        
        return (message, null);
    }
}


/// <summary>
/// Retrieves the information about a wikipedia page in a JSON object
/// </summary>
public static class PageTool
{
    public const string Name = "read-wikipedia-article-tool";

    private const string Description =
        """
        Retrieves the information about the wikipedia article as JSON object.
        The JSON object contains information like Id, Title and Url and the content of the article in the wikitext format
        """;

    private static readonly JsonElement InputSchema = Helper.ToJsonSchema<TitleInput>();
    private static readonly JsonElement OutputSchema = Helper.ToJsonSchema<McpOutput<PageOutput>>();

    public static async ValueTask<CallToolResult> RunAsync(
        HttpClient httpClient,
        RequestContext<CallToolRequestParams> request,
        CancellationToken ct)
    {
        TitleInput input = TitleInput.From(request.Params!.Arguments!);

        string url = $"page/{input.Title}";
        using HttpResponseMessage response = await httpClient.GetAsync(url, ct);
        if (!response.IsSuccessStatusCode)
        {
            throw await WikipediaException.FromAsync<PageErrorContext>(response, ct);
        }

        Wikipedia.Page result = await response.Content.ReadFromJsonAsync<Wikipedia.Page>(ct);
        PageOutput output = new PageOutput(
            result.Title,
            result.PageLatest,
            result.ContentModel,
            result.Source!);

        return Helper.AsStructuredContent(new McpOutput<PageOutput>("object", output));
    }
    
    public static Tool Tool() =>
        new()
        {
            Name = Name,
            Description = Description,
            Title = "Read Article Tool",
            InputSchema = InputSchema,
            OutputSchema = OutputSchema,
        };
}