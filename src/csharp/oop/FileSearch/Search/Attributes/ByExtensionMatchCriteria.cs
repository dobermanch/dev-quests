using Microsoft.Extensions.FileProviders;

namespace FileSearch.Search.Attributes;

public sealed class ByExtensionMatchCriteria(string expectedValue, bool isRegex = false)
    : StringMatchCriteriaBase(isRegex ? expectedValue : $"{expectedValue.Trim().Trim('.')}", isRegex)
{
    protected override string GetAttributeValue(IFileInfo fileInfo, SearchOptions options)
        => Path.GetExtension(fileInfo.Name).Trim('.');
}