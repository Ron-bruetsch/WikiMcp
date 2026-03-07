using System.Net;
using System.Text.Json.Serialization;

namespace Server.Errors;

public interface IErrorContext
{
    public static abstract (string, string?) FromStatusCode(ErrorResponseObject model);
}

[method: JsonConstructor]
public readonly struct ErrorResponseObject(
    string error,
    string name,
    Dictionary<string, string> messageTranslation,
    string failureCode,
    string? failureData,
    string errorCode,
    ushort httpCode)
{
    [JsonPropertyName("error")]
    public string Error { get; } = error;
    
    [JsonPropertyName("message")]
    public string Name { get; } = name;

    [JsonPropertyName("messageTranslations")]
    public Dictionary<string, string> MessageTranslation { get; } = messageTranslation;
    
    [JsonPropertyName("failureCode")]
    public string FailureCode { get; } = failureCode;
    
    [JsonPropertyName("failureData")]
    public string? FailureData { get; } = failureData;
    
    [JsonPropertyName("errorCode")]
    public string ErrorCode { get; } = errorCode;

    [JsonPropertyName("httpCode")]
    public ushort HttpCode { get; } = httpCode;
}

/// <summary>
/// This class represents http error status codes coming from Wikipedia
/// </summary>
public sealed class WikipediaException : Exception
{
    public HttpStatusCode ErrorCode { get; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Instruction { get; }

    private WikipediaException(
        HttpStatusCode errorCode,
        string? instruction,
        string message) : base(message)
    {
        ErrorCode = errorCode;
        Instruction = instruction;
    }

    public static async ValueTask<WikipediaException> FromAsync<TCtx>(
        HttpResponseMessage response,
        CancellationToken cancellationToken) where TCtx : IErrorContext
    {
        ErrorResponseObject model = await response.Content.ReadFromJsonAsync<ErrorResponseObject>(cancellationToken);
        
        (string message, string? instruction) = TCtx.FromStatusCode(model);

        return new WikipediaException(
            response.StatusCode,
            instruction,
            message);
    }
}