using System.Text.Json.Serialization;

namespace Server.Tools;

/// <summary>
/// Little wrapper object to handle paged results
/// </summary>
/// <param name="items"></param>
/// <typeparam name="T"></typeparam>
[method: JsonConstructor]
public readonly struct Paged<T>(
    IEnumerable<T> items)
{
    public IEnumerable<T> Items { get; } = items;   
}
