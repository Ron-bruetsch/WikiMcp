using System.ComponentModel;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Schema;
using System.Text.Json.Serialization.Metadata;
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

    private static readonly JsonSerializerOptions Options = new()
    {
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        TypeInfoResolver = new DefaultJsonTypeInfoResolver()
    };
        
    public static JsonElement ToJsonSchema<T>()
    {
        JsonNode schemaNode = Options.GetJsonSchemaAsNode(typeof(T), new JsonSchemaExporterOptions
        {
            TransformSchemaNode = (ctx, schema) =>
            {
                var desc = ctx.PropertyInfo?.AttributeProvider
                    ?.GetCustomAttributes(typeof(DescriptionAttribute), true)
                    .OfType<DescriptionAttribute>()
                    .FirstOrDefault();

                if (desc is not null)
                    schema["description"] = desc.Description;

                return schema;
            }
        });
        
        return JsonElement.Parse(schemaNode.ToJsonString());
    }
}