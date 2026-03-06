using System.Text.Json;
using System.Text.Json.Schema;
using ModelContextProtocol.Protocol;
using ModelContextProtocol.Server;

namespace Server.Tools.Search;

/// <summary>
/// Handles to logic for calling search APIs of Wikipedia and return the results as JSON
/// </summary>
public static class SearchTool
{
    private static readonly JsonElement InputSchema = JsonDocument
        .Parse(JsonSerializer.SerializeToUtf8Bytes(
            JsonSerializerOptions.Default.GetJsonSchemaAsNode(typeof(SearchInput))))
        .RootElement
        .Clone();

    private static readonly JsonElement OutputSchema = JsonDocument.Parse(
            JsonSerializer.SerializeToUtf8Bytes(
                JsonSerializerOptions.Default.GetJsonSchemaAsNode(typeof(SearchInput))))
        .RootElement.Clone();
    
    public static async ValueTask<CallToolResult> RunAsync(
        HttpClient httpClient,
        RequestContext<CallToolRequestParams> request,
        CancellationToken ct)
    {
        SearchInput input = SearchInput.From(request.Params!.Arguments!);
        string url = input.Type switch
        {
            SearchType.Keyword => "search/page/",
            SearchType.Title => "search/title/",
            _ => throw new NotSupportedException(
                $"Wikipedia search type {input.Type} not implemented")
        };

        url = $"{url}?p={input.Term}&limit={input.Limit}";
        using HttpResponseMessage response = await httpClient.GetAsync(url, ct);
        response.EnsureSuccessStatusCode();

        Paged<Transfer.Search> page = await response.Content.ReadFromJsonAsync<Paged<Transfer.Search>>(ct);
        IEnumerable<SearchOutput> output = page.Items.Select(x => new SearchOutput(x.Title, x.Excerpt, x.Description, x.Thumbnail));
        
        return new CallToolResult()
        {
            IsError = false,
            StructuredContent = JsonSerializer.SerializeToElement(output)
        };
    }
    
    public static Tool Tool() =>
        new()
        {
            Name = "search-wikipedia-tool",
            Description = "Allows to search wikipedia by keywords and titles",
            Title = "Search Wikipedia Tool",
            InputSchema = InputSchema,
            OutputSchema = OutputSchema,
        };
}