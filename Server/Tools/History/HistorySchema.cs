using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Serialization;
using Server.Wikipedia;

namespace Server.Tools.History;

public enum HistoryFilter
{
    Reverted,
    Anonymous,
    Bot,
    Minor
}

[method: JsonConstructor]
public readonly struct HistoryInput(
    string title,
    uint? olderThan,
    uint? newerThan,
    HistoryFilter filter)
{
    [Description("The title of the wikipedia article")]
    public string Title { get; } = title;

    [Description("The revision ID. Returns the next 20 revisions older than the given revision ID")]
    public uint? OlderThan { get; } = olderThan;

    [Description("The revision ID. Returns the next 20 revisions newer than the given revision ID")]
    public uint? NewerThan { get; } = newerThan;

    [Description("Filter that returns only revisions with certain tags")]
    public HistoryFilter Filter { get; } = filter;

    public static HistoryInput From(IDictionary<string, JsonElement> arguments)
    {
        throw new NotImplementedException();
    }
}


public readonly struct HistoryOutput(
    uint id,
    PageInfo page,
    User user,
    uint size,
    bool minor,
    string timestamp,
    int? delta,
    string? comment)
{
    public uint Id { get; } = id;
    
    public PageInfo Page { get; } = page;
    
    public User User { get; } = user;
    
    public uint Size { get; } = size;
    
    public bool Minor { get; } = minor;
    
    public string Timestamp { get; } = timestamp;
    
    public int? Delta { get; } = delta;
    
    public string? Comment { get; } = comment;
    
    public HistoryOutput(Revision model) : this(
        model.Id,
        model.Page,
        model.User,
        model.Size,
        model.Minor,
        model.Timestamp,
        model.Delta,
        model.Comment)
    {
        
    } 
}