using ModelContextProtocol.Protocol;
using ModelContextProtocol.Server;

namespace Server;

internal static class Program
{
    private const string BaseUrl = "https://en.wikipedia.org/w/rest.php/v1/";
    private static readonly HttpClient _httpClient = new();
    
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

    public static ValueTask<ListToolsResult> ListToolsAsync(RequestContext<ListToolsRequestParams> request, CancellationToken ct) =>
        throw new NotImplementedException();

    public static ValueTask<CallToolResult> CallToolAsync(RequestContext<CallToolRequestParams> request,
        CancellationToken ct) =>
        throw new NotImplementedException();
}