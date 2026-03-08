using System.Net.Http.Headers;
using System.Text.Encodings.Web;
using System.Text.Json;
using HtmlAgilityPack;
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
/// Reads the plain content of the wikipedia page in the wikitext format
/// </summary>
public static class HtmlPageTool
{
    public const string Name = "read-wikipedia-page-content-tool";

    private static readonly JsonElement InputSchema = Helper.ToJsonSchema(typeof(PageInput));

    public static async ValueTask<CallToolResult> RunAsync(
        HttpClient httpClient,
        RequestContext<CallToolRequestParams> request,
        CancellationToken ct)
    {
        if (!request.Params!.Arguments!.TryGetValue("title", out JsonElement titleJson))
        {
            throw new WikiMcpException(
                "Expected parameter 'title'",
                "Include this parameter in the request.");
        }
        
        string title = titleJson.GetString()!;
        
        string url = $"page/{title}/html?redirect=no&flavor=edit";
        
        using HttpResponseMessage response = await httpClient.GetAsync(url, ct);
        if (!response.IsSuccessStatusCode)
        {
            throw await WikipediaException.FromAsync<PageErrorContext>(response, ct);
        }

        url = $"transform/html/to/wikitext/{title}";
        string html = await response.Content.ReadAsStringAsync(ct); 
        var dom = new HtmlDocument();
        dom.LoadHtml(html);
        
        var bodyNode = dom.DocumentNode.SelectSingleNode("//body");
        var fragment = bodyNode?.InnerHtml ?? html;

        using HttpRequestMessage message = new(HttpMethod.Post, url);
        message.Content = new StringContent(JsonSerializer.Serialize(new ConvertObject(fragment),
            new JsonSerializerOptions() { Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping }));
        
        message.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
        
        using HttpResponseMessage convertResponse = await httpClient.SendAsync(
            message, 
            ct);
        
        if (!convertResponse.IsSuccessStatusCode)
        {
            var error = await convertResponse.Content.ReadAsStringAsync(ct);
            Console.WriteLine(error);
        }
        
        string wikitext = await convertResponse.Content.ReadAsStringAsync(ct);
        return new CallToolResult()
        {
            IsError = false,
            Content =
            [
                new TextContentBlock()
                {
                    Text = wikitext
                }
            ]
        };
    }

    public static Tool Tool() =>
        new()
        {
            Name = Name,
            Description = "Read the plain content in the wikitext format of the specified wikipedia page",
            Title = "Read Page Content Tool",
            InputSchema = InputSchema
        };
}

/// <summary>
/// Retrieves the information about a wikipedia page in a JSON object
/// </summary>
public static class PageTool
{
    public const string Name = "read-wikipedia-page-tool";

    private static readonly JsonElement InputSchema = Helper.ToJsonSchema(typeof(PageInput));
    private static readonly JsonElement OutputSchema = Helper.ToJsonSchema(typeof(McpOutput<PageOutput>));

    public static async ValueTask<CallToolResult> RunAsync(
        HttpClient httpClient,
        RequestContext<CallToolRequestParams> request,
        CancellationToken ct)
    {
        PageInput input = PageInput.From(request.Params!.Arguments!);
        string url = input.Mode switch
        {
            "bare" => $"page/{input.Title}/bare",
            "html" => $"page/{input.Title}/with_html",
            _ => throw new WikiMcpException(
                "The provided mode is not supported.", 
                "Use 'bare' or 'html' instead.")
        };

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
            result.HtmlUrl,
            result.Html,
            result.Source);
        
        return new CallToolResult()
        {
            IsError = false,
            StructuredContent = JsonSerializer.SerializeToElement(output)
        };
    }
    
    public static Tool Tool() =>
        new()
        {
            Name = Name,
            Description = "Reads the information about the wikipedia page as JSON object",
            Title = "Read Page Tool",
            InputSchema = InputSchema,
            OutputSchema = OutputSchema,
        };
}