using Microsoft.Extensions.FileProviders;

namespace FileSearch.Search.Attributes;

public sealed class ByNameMatchCriteria(string expectedValue, bool isRegex = false)
    : StringMatchCriteriaBase(isRegex ? expectedValue : $"{expectedValue.Trim()}", isRegex)
{
    protected override string GetAttributeValue(IFileInfo fileInfo, SearchOptions options)
        => Path.GetFileNameWithoutExtension(fileInfo.Name);
}