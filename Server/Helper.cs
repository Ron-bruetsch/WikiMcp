using System.Text.Json;
using System.Text.Json.Schema;
using ModelContextProtocol.Protocol;

namespace Server;

public static class Helper
{
    public static CallToolResult AsJsonResult<T>(T model)
    {
        return new CallToolResult()
        {
            IsError = false,
            Content =
            [
                new TextContentBlock()
                {
                    Text = JsonSerializer.Serialize(model),
                }
            ]
        };
    }

    public static CallToolResult AsStructuredContent<T>(T model)
    {
        return new CallToolResult()
        {
            IsError = false,
            StructuredContent = JsonSerializer.SerializeToElement(model),
        };
    }
    
    public static JsonElement ToJsonSchema(Type type) =>
        JsonDocument
            .Parse(JsonSerializer.SerializeToUtf8Bytes(
                JsonSerializerOptions.Default.GetJsonSchemaAsNode(type))).RootElement;
}