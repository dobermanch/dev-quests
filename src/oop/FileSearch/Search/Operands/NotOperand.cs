using Microsoft.Extensions.FileProviders;

namespace FileSearch.Search.Operands;

public sealed class NotOperand(IMatchCriteria criteria) : OperandCriteriaBase
{
    public override bool IsMatch(IFileInfo fileInfo, SearchOptions options)
        => !criteria.IsMatch(fileInfo, options);
}