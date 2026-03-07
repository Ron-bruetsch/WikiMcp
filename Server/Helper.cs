using System.Text.Json;
using System.Text.Json.Schema;

namespace Server;

public static class Helper
{
    public static JsonElement ToJsonSchema(Type type) =>
        JsonDocument
            .Parse(JsonSerializer.SerializeToUtf8Bytes(
                JsonSerializerOptions.Default.GetJsonSchemaAsNode(type))).RootElement;
}