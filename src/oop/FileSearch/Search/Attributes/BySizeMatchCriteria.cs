using Microsoft.Extensions.FileProviders;

namespace FileSearch.Search.Attributes;

public sealed class BySizeMatchCriteria(long expectedValue, ComparisonOperandType comparisonOperandType)
    : ComparisonMatchCriteriaBase<long>(expectedValue, comparisonOperandType)
{
    protected override long GetAttributeValue(IFileInfo fileInfo, SearchOptions options)
        => fileInfo.Length;
}