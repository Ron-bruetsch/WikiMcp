using System.Text.Json;
using ModelContextProtocol.Protocol;
using ModelContextProtocol.Server;
using Server.Errors;
using Server.Tools.Page;
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
    public const string Name = "retrieve-article-images-tool";
    private const string Description =
        """
        Retrieves images related to the Wikipedia article identified by the provided title 
        """;

    private static readonly JsonElement InputSchema = Helper.ToJsonSchema<TitleInput>();
    
    public static async ValueTask<CallToolResult> RunAsync(
        HttpClient httpClient,
        RequestContext<CallToolRequestParams> request,
        CancellationToken ct)
    {
        TitleInput input = TitleInput.From(request.Params!.Arguments!);
        string url = $"page/{input.Title}/links/media";
        
        using HttpResponseMessage response = await httpClient.GetAsync(url, ct);

        if (!response.IsSuccessStatusCode)
        {
            throw await WikipediaException.FromAsync<MediaFileErrorContext>(response, ct);
        }
        
        FilesPage content = await response.Content.ReadFromJsonAsync<FilesPage>(ct);
        List<Task<ContentBlock?>> tasks = content.Items!.Select(x => TryIntoFileContentAsync(httpClient, x, ct)).ToList();

        ContentBlock?[] imageContents = await Task.WhenAll(tasks);

        IEnumerable<ContentBlock> output = imageContents
            .Where(x => x is not null)
            .Select(x => x!);
        
        return new CallToolResult()
        {
            IsError = false,
            Content = [..output]
        };
    }
    
    private static async Task<ContentBlock?> TryIntoFileContentAsync(
        HttpClient httpClient,
        MediaFile model, CancellationToken ct) 
    {
        try
        {
            if (model.Preferred is { } preferred)
            {
                if (preferred.Mimetype == "DRAWING" || preferred.Mimetype == "BITMAP")
                {
                    return await IntoFileContentAsync(httpClient, preferred, ct);
                }

            }

            if (model.Original is { } original)
            {
                if (original.Mimetype == "DRAWING" || original.Mimetype == "BITMAP")
                {
                    return await IntoFileContentAsync(httpClient, original, ct);
                }
            }
        }
        catch (Exception)
        {
            return null;
        }

        return null;
    }

    private static async Task<ContentBlock> IntoFileContentAsync(
        HttpClient httpClient,
        Thumbnail model,
        CancellationToken ct)
    {
        using HttpResponseMessage response = await httpClient.GetAsync(model.Url, ct);
        if (!response.IsSuccessStatusCode)
        {
            throw await WikipediaException.FromAsync<MediaFileErrorContext>(response, ct);
        }

        if (response.Content.Headers.ContentType?.MediaType == "image/svg+xml")
        {
            return new TextContentBlock()
            {
                Text = await response.Content.ReadAsStringAsync(ct)
            };
        }

        byte[] data = await response.Content.ReadAsByteArrayAsync(ct);
        return ImageContentBlock.FromBytes(data, response.Content.Headers.ContentType?.MediaType ?? "image/svg+xml");
    }

    public static Tool Tool() =>
        new()
        {
            Name = Name,
            Description = Description,
            Title = "Retrieve Article Images Tool",
            InputSchema = InputSchema,
        };
}