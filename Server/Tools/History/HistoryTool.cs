using System.Text;
using System.Text.Json;
using ModelContextProtocol.Protocol;
using ModelContextProtocol.Server;
using Server.Errors;
using Server.Wikipedia;

namespace Server.Tools.History;

public readonly struct HistoryErrorContext : IErrorContext
{
    public static (string, string?) FromStatusCode(ErrorResponseObject model)
    {
        switch (model.HttpCode)
        {
            case 400:
                throw new NotImplementedException();
            case 404:
                return ("Title or revision not found", null);
            default:
                throw new NotSupportedException(
                    $"Handling error code {model.HttpCode} for history tool is not supported.");
        }
    }
}

public static class HistoryTool
{
    public const string Name = "get-article-history";

    private static readonly JsonElement InputSchema = Helper.ToJsonSchema(typeof(HistoryInput));
    private static readonly JsonElement OutputSchema = Helper.ToJsonSchema(typeof(McpOutput<IEnumerable<HistoryOutput>>));
    
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
            var body = await response.Content.ReadAsStringAsync(ct);
            Console.WriteLine(body);
            //throw await WikipediaException.FromAsync<HistoryErrorContext>(response, ct);     
        }

        Paged<Revision> page = await response.Content.ReadFromJsonAsync<Paged<Revision>>(ct);
        IEnumerable<HistoryOutput> output = page.Revisions!.Select(x => new HistoryOutput(x));
        
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
            Description = "Retrieves the change history of a specific Wikipedia article",
            Title = "Get Article History",
            InputSchema = InputSchema,
            OutputSchema = OutputSchema,
        };
}