using System.Text.Json;
using System.Text.Json.Schema;
using ModelContextProtocol.Protocol;
using ModelContextProtocol.Server;
using Server.Errors;

namespace Server.Tools.Search;

public readonly struct SearchErrorContext : IErrorContext
{
    public static (string, string?) FromStatusCode(ErrorResponseObject model)
    {
        return model.HttpCode switch
        {
            400 => (model.MessageTranslation["en"], null),
            500 => ("Search error on the wikipedia server", null),
            _ => throw new NotSupportedException(
                $"Handling error code {model.HttpCode} for search tool is not supported.")
        };
    }
}

/// <summary>
/// Handles to logic for calling search APIs of Wikipedia and return the results as JSON
/// </summary>
public static class SearchTool
{
    public const string Name = "search-wikipedia-tool";
    
    private static readonly JsonElement InputSchema = JsonDocument
        .Parse(JsonSerializer.SerializeToUtf8Bytes(
            JsonSerializerOptions.Default.GetJsonSchemaAsNode(typeof(SearchInput))))
        .RootElement;

    private static readonly JsonElement OutputSchema = JsonDocument.Parse(
            JsonSerializer.SerializeToUtf8Bytes(
                JsonSerializerOptions.Default.GetJsonSchemaAsNode(typeof(McpOutput<IEnumerable<SearchOutput>>))))
        .RootElement;
    
    public static async ValueTask<CallToolResult> RunAsync(
        HttpClient httpClient,
        RequestContext<CallToolRequestParams> request,
        CancellationToken ct)
    {
        SearchInput input = SearchInput.From(request.Params!.Arguments!);
        string url = input.SearchMode switch
        {
            "keyword" => "search/page",
            "title" => "search/title",
            _ => throw new WikiMcpException(
                "Server error",
                $"Wikipedia search type '{input.SearchMode}' is not supported. Supported values are 'keyword' or 'title'.")
        };

        url = $"{url}?q={input.Term}&limit={input.Limit}";
        
        using HttpResponseMessage response = await httpClient.GetAsync(url, ct);

        if (!response.IsSuccessStatusCode)
        {
            throw await WikipediaException.FromAsync<SearchErrorContext>(response, ct);
        }

        Paged<Wikipedia.Search> page = await response.Content.ReadFromJsonAsync<Paged<Wikipedia.Search>>(ct);
        IEnumerable<SearchOutput> output = page.Pages!.Select(x =>
            new SearchOutput(x.Title, x.Excerpt, x.Description, x.Thumbnail));

        return Helper.AsStructuredContent(new McpOutput<IEnumerable<SearchOutput>>("object", output));
    }
    
    public static Tool Tool() =>
        new()
        {
            Name = Name,
            Description = "Allows to search wikipedia by keywords and titles",
            Title = "Search Tool",
            InputSchema = InputSchema,
            OutputSchema = OutputSchema,
        };
}