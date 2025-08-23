using Microsoft.Extensions.FileProviders;

namespace FileSearch.Search.Operands;

public sealed class OrOperand(IReadOnlyCollection<IMatchCriteria> predicates) : OperandCriteriaBase
{
    public override bool IsMatch(IFileInfo fileInfo, SearchOptions options)
        => predicates.Any(it => it.IsMatch(fileInfo, options));
}