using Microsoft.Extensions.FileProviders;

namespace FileSearch.Search.Attributes;

public abstract class AttributeMatchCriteriaBase<T>(T expectedValue) : IMatchCriteria
{
    public bool IsMatch(IFileInfo fileInfo, SearchOptions options)
    {
        if (fileInfo is not { Exists: true })
        {
            return false;
        }

        var currentValue = GetAttributeValue(fileInfo, options);
        return Compare(currentValue, expectedValue, options);
    }

    protected abstract T GetAttributeValue(IFileInfo fileInfo, SearchOptions options);

    protected abstract bool Compare(T currentValue, T expectedValue, SearchOptions options);
}