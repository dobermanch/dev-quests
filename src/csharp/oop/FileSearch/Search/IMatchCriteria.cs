using Microsoft.Extensions.FileProviders;

namespace FileSearch.Search;

public interface IMatchCriteria
{
    bool IsMatch(IFileInfo fileInfo, SearchOptions options);
}