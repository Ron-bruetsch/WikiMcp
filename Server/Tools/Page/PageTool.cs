using System.Text.Json;
using System.Text.Json.Schema;
using ModelContextProtocol.Protocol;
using ModelContextProtocol.Server;

namespace Server.Tools.Page;

public static class PageTool
{
    public const string Name = "read-wikipedia-page-tool";
    
    private static readonly JsonElement InputSchema = JsonDocument
        .Parse(JsonSerializer.SerializeToUtf8Bytes(
            JsonSerializerOptions.Default.GetJsonSchemaAsNode(typeof(PageInput)))).RootElement;
    
    private static readonly JsonElement OutputSchema = JsonDocument
        .Parse(JsonSerializer.SerializeToUtf8Bytes(
            JsonSerializerOptions.Default.GetJsonSchemaAsNode(typeof(PageOutput)))).RootElement;

    public static async ValueTask<CallToolResult> RunAsync(
        HttpClient httpClient,
        RequestContext<CallToolRequestParams> request,
        CancellationToken ct)
    {
        PageInput input = PageInput.From(request.Params!.Arguments!);
        string url = input.Mode switch
        {
            PageMode.Bare => $"page/{input.Title}/bare/",
            PageMode.WithHtml => $"page/{input.Title}/with_html",
            PageMode.Html => $"page/{input.Title}/html",
            _ => throw new ArgumentOutOfRangeException()
        };

        using HttpResponseMessage response = await httpClient.GetAsync(url, ct);
        response.EnsureSuccessStatusCode();

        return input.Mode switch
        {
            PageMode.Html => new CallToolResult()
            {
                Content =
                [
                    new TextContentBlock()
                    {
                        Text = await response.Content.ReadAsStringAsync(ct)
                    }
                ]
            },
            _ => await FromStructuredAsync(response, ct)
        };
    }

    private static async ValueTask<CallToolResult> FromStructuredAsync(
        HttpResponseMessage response,
        CancellationToken ct)
    { 
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
            Description = "Read wikipedia pages with or without the complete html page",
            Title = "Read Wikipedia Page Tool",
            InputSchema = InputSchema,
            OutputSchema = OutputSchema,
        };
}