using System.Net.Http.Headers;
using System.Text.Json;
using ModelContextProtocol.Protocol;
using ModelContextProtocol.Server;
using Server.Errors;
using Server.Tools.History;
using Server.Tools.Media;
using Server.Tools.Page;
using Server.Tools.Search;

namespace Server;

// todo: https://learn.microsoft.com/en-us/aspnet/web-api/overview/security/basic-authentication
// todo: https://learn.microsoft.com/en-us/aspnet/core/security/authentication/configure-jwt-bearer-authentication?view=aspnetcore-10.0

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
                HtmlPageTool.Tool(),
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
                HtmlPageTool.Name => await  HtmlPageTool.RunAsync(HttpClient, request, ct),
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
        return ex switch
        {
            WikiMcpException or WikipediaException => new CallToolResult()
            {
                IsError = true,
                StructuredContent = JsonSerializer.SerializeToElement(ex)
            },
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