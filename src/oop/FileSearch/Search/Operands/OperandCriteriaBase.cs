using Microsoft.Extensions.FileProviders;

namespace FileSearch.Search.Operands;

public abstract class OperandCriteriaBase : IMatchCriteria
{
    public abstract bool IsMatch(IFileInfo fileInfo, SearchOptions options);
}