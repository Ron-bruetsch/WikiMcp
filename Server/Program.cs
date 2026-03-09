using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using ModelContextProtocol.Protocol;
using ModelContextProtocol.Server;
using Server.Errors;
using Server.Tools;
using Server.Tools.History;
using Server.Tools.Media;
using Server.Tools.Page;
using Server.Tools.Search;

namespace Server;

internal static class Program
{
    private const string BaseUrl = "https://en.wikipedia.org/w/rest.php/v1/";
    private static readonly HttpClient HttpClient;
    
    static Program()
    {
        HttpClient = new HttpClient();
        HttpClient.BaseAddress = new Uri(BaseUrl);
        HttpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("WikiMcp", "1.0"));
    }
    
    private const string Index =
        """
        <html>
            <head>
                <title>WikiMcp</title>
            </head>
            <body>
                <h1>Welcome to the WikiMcp server!</h1>
            </body>
        </html>
        """;
    
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        builder.Services.AddMcpServer()
            .WithHttpTransport()
            .WithListToolsHandler(ListToolsAsync)
            .WithCallToolHandler(CallToolAsync);
        
        WebApplication app = builder.Build();

        app.MapGet("/", (x) =>
        {
            x.Response.ContentType = "text/html";
            return x.Response.WriteAsync(Index);
        });
        
        app.MapMcp("/mcp");
            
        app.Run();
    }

    private static ValueTask<ListToolsResult> ListToolsAsync(RequestContext<ListToolsRequestParams> request, CancellationToken ct) =>
        ValueTask.FromResult(new ListToolsResult()
        {
            Tools = [
                SearchTool.Tool(),
                PageTool.Tool(),
                MediaFileTool.Tool(),
                HistoryTool.Tool()
            ]
        });

    private static async ValueTask<CallToolResult> CallToolAsync(
        RequestContext<CallToolRequestParams> request,
        CancellationToken ct)
    {
        try
        {
            return request.Params!.Name switch
            {
                SearchTool.Name => await SearchTool.RunAsync(HttpClient, request, ct),
                PageTool.Name => await PageTool.RunAsync(HttpClient, request, ct), 
                MediaFileTool.Name => await MediaFileTool.RunAsync(HttpClient, request, ct),
                HistoryTool.Name => await HistoryTool.RunAsync(HttpClient, request, ct),
                _ => NotFoundError(request.JsonRpcRequest.Method)
            };
        }
        catch (Exception ex)
        {
            return FromException(ex);
        }
    }

    private static CallToolResult FromException(Exception ex)
    {
        McpOutput<IEnumerable<ErrorResponse>> error = ex switch
        {
            WikiMcpException exception => new McpOutput<IEnumerable<ErrorResponse>>(
                "object", 
                [new WikiErrorResponse(exception)]),
            _ => new McpOutput<IEnumerable<ErrorResponse>>("object", [new ErrorResponse("Server error", ex)])
        };

        return new CallToolResult()
        {
            IsError = true,
            StructuredContent = JsonSerializer.SerializeToElement(error)
        };
    }
    
    private static CallToolResult NotFoundError(string name) =>
        new()
        {
            IsError = true,
            Content =
            [
                new TextContentBlock()
                {
                    Text = $"Tool {name} does not exist!"
                }
            ]
        };
}

public class ErrorResponse(
    string title,
    Exception ex)
{
    public string Title { get; } = title;
    
    public string Message { get; } = ex.Message;
}

public sealed class WikiErrorResponse(
    WikiMcpException ex) : ErrorResponse(ex.Title, ex)
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Instruction { get; } = ex.Instruction;
}