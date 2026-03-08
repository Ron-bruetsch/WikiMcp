using System.Text.Json.Serialization;

namespace Server.Errors;

public class WikiMcpException(string message, string? instruction=null) : Exception(message)
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Instruction { get; } = instruction;
}