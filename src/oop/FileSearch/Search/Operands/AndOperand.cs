using Microsoft.Extensions.FileProviders;

namespace FileSearch.Search.Operands;

public sealed class AndOperand(IReadOnlyCollection<IMatchCriteria> predicates) : OperandCriteriaBase
{
    public override bool IsMatch(IFileInfo fileInfo, SearchOptions options)
        => predicates.All(it => it.IsMatch(fileInfo, options));
}