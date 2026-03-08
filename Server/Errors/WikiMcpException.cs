using System.Text.Json.Serialization;

namespace Server.Errors;

public class WikiMcpException(string title, string message, string? instruction=null) : Exception(message)
{
    public string Title { get; } = title;

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Instruction { get; } = instruction;
}