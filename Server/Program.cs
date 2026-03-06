using ModelContextProtocol.Protocol;
using ModelContextProtocol.Server;
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
            ]
        });

    private static ValueTask<CallToolResult> CallToolAsync(
        RequestContext<CallToolRequestParams> request,
        CancellationToken ct)
    {
        try
        {
            return request.Params!.Name switch
            {
                "search-wikipedia-tool" => SearchTool.RunAsync(HttpClient, request, ct),
                _ => ValueTask.FromResult(NotFoundError(request.JsonRpcRequest.Method))
            };
        }
        catch (Exception ex)
        {
            return ValueTask.FromResult(FromException(ex));
        }
    }

    private static CallToolResult FromException(Exception ex)
    {
        return ex switch
        {
            _ => new CallToolResult()
            {
                IsError = true,
                Content =
                [
                    new TextContentBlock()
                    {
                        Text = ex.Message
                    }
                ]
            }
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