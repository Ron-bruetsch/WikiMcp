using System.Text.Json;
using ModelContextProtocol.Protocol;
using ModelContextProtocol.Server;
using Server.Errors;
using Server.Wikipedia;

namespace Server.Tools.Media;

public readonly struct MediaFileErrorContext  : IErrorContext
{
    public static (string, string?) FromStatusCode(ErrorResponseObject model)
    {
        return model.HttpCode switch
        {
            400 => (
                "The wikipedia article contains more then 100 media files. This is not supported by the wikipedia API",
                null),
            404 => ("The requested title was not found", null),
            _ => throw new WikiMcpException(
                "Server error",
                $"Handling error code {model.HttpCode} for media file tool is not supported.")
        };
    }
}

/// <summary>
/// Retrieves the media files from a specific Wikipedia page 
/// </summary>
public static class MediaFileTool
{
    public const string Name = "retrieve-media-files-tool";

    private static readonly JsonElement InputSchema = Helper.ToJsonSchema(typeof(MediaFileInput));
    
    public static async ValueTask<CallToolResult> RunAsync(
        HttpClient httpClient,
        RequestContext<CallToolRequestParams> request,
        CancellationToken ct)
    {
        MediaFileInput input = MediaFileInput.From(request.Params!.Arguments!);
        string url = $"page/{input.Title}/links/media";
        
        using HttpResponseMessage response = await httpClient.GetAsync(url, ct);

        if (!response.IsSuccessStatusCode)
        {
            throw await WikipediaException.FromAsync<MediaFileErrorContext>(response, ct);
        }
        
        Paged<MediaFile> content = await response.Content. ReadFromJsonAsync<Paged<MediaFile>>(ct);
        IEnumerable<Task<ImageContentBlock>> tasks = content.Files!.Select(x => IntoFileContentAsync(httpClient, x, ct));
        
        return new CallToolResult()
        {
            IsError = false,
            Content = [..await Task.WhenAll(tasks)]
        };
    }
    
    private static async Task<ImageContentBlock> IntoFileContentAsync(
        HttpClient httpClient,
        MediaFile model, CancellationToken ct) 
    {
        if (model.Preferred is { } preferred)
        {
            return await IntoFileContentAsync(httpClient, preferred, ct);
        }

        if (model.Original is { } original)
        {
            return await IntoFileContentAsync(httpClient, original, ct);            
        }
        
        throw new WikiMcpException(
            "Server error",
            "Only getting preferred and original media files are supported.");
    }

    private static async Task<ImageContentBlock> IntoFileContentAsync(
        HttpClient httpClient,
        Thumbnail model,
        CancellationToken ct)
    {
        using HttpResponseMessage response = await httpClient.GetAsync(model.Url, ct);
        if (!response.IsSuccessStatusCode)
        {
            throw await WikipediaException.FromAsync<MediaFileErrorContext>(response, ct);
        }
            
        return new ImageContentBlock()
        {
            Data = await response.Content.ReadAsByteArrayAsync(ct),
            MimeType = response.Content.Headers.ContentType?.MediaType ?? "image/svg+xml",
        };
    }

    public static Tool Tool() =>
        new()
        {
            Name = Name,
            Description = "This retrieves media files for a specific Wikipedia article",
            Title = "Retrieve Media File Tool",
            InputSchema = InputSchema,
        };
}