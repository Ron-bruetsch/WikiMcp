using System.Text;
using System.Text.Json;
using ModelContextProtocol.Protocol;
using ModelContextProtocol.Server;
using Server.Errors;

namespace Server.Tools.History;

public readonly struct HistoryErrorContext : IErrorContext
{
    public static (string, string?) FromStatusCode(ErrorResponseObject model)
    {
        switch (model.HttpCode)
        {
            case 400:
                return (model.MessageTranslation["en"], "Fix the arguments in the request");
            case 404:
                return ("Title or revision not found", null);
            default:
                throw new WikiMcpException(
                    "Server error",
                    $"Handling error code '{model.HttpCode}' for history tool is not supported.");
        }
    }
}

public static class HistoryTool
{
    public const string Name = "retrieve-article-history";

    private const string Description =
        """
        Retrieves the change history of the Wikipedia article identified by the title
        """;

    private static readonly JsonElement InputSchema = Helper.ToJsonSchema<HistoryInput>();
    private static readonly JsonElement OutputSchema = Helper.ToJsonSchema<McpOutput<IEnumerable<HistoryOutput>>>();
    
    public static async ValueTask<CallToolResult> RunAsync(
        HttpClient httpClient,
        RequestContext<CallToolRequestParams> requestContext,
        CancellationToken ct)
    {
        HistoryInput input = HistoryInput.From(requestContext.Params!.Arguments!);
        StringBuilder urlBuilder = new($"page/{input.Title}/history");

        bool first = true;
        if (!string.IsNullOrWhiteSpace(input.Filter))
        {
            urlBuilder.Append(first ? $"?filter={input.Filter}" : $"&filter={input.Filter}");
            first = false;
        }
        
        if (input.OlderThan is { } ot)
        {
            urlBuilder.Append(first ? $"?older_than={ot}" : $"&older_than={ot}");
            first = false;
        }
        
        if (input.NewerThan is { } nt)
        {
            urlBuilder.Append(first ? $"?newer_than={nt}" : $"&newer_than={nt}");
        }
        
        string url = urlBuilder.ToString();
        
        using HttpResponseMessage response = await httpClient.GetAsync(url, ct);
        
        if (!response.IsSuccessStatusCode)
        { 
            throw await WikipediaException.FromAsync<HistoryErrorContext>(response, ct);     
        }

        RevisionPage page = await response.Content.ReadFromJsonAsync<RevisionPage>(ct);
        IEnumerable<HistoryOutput> output = page.Items!.Select(x => new HistoryOutput(x));

        return Helper.AsStructuredContent(new McpOutput<IEnumerable<HistoryOutput>>("object", output));
    }

    public static Tool Tool() =>
        new()
        {
            Name = Name,
            Description = Description,
            Title = "Retrieve Article History",
            InputSchema = InputSchema,
            OutputSchema = OutputSchema,
        };
}