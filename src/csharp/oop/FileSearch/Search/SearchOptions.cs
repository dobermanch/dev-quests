namespace FileSearch.Search;

public sealed record SearchOptions
{
    public bool IsRecursive { get; init; } = true;
    public bool IsCaseSensitive { get; init; }
}