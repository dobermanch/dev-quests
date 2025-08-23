using Microsoft.Extensions.FileProviders;

namespace FileSearch.Search;

public sealed class SearchEngine(IFileProvider fileProvider)
{
    public SearchEngine(string rootPath)
        : this(new PhysicalFileProvider(rootPath)) { }

    public IEnumerable<IFileInfo> Search(IMatchCriteria criteria, SearchOptions? searchOptions = null)
    {
        if (criteria is null)
        {
            return [];
        }
        
        searchOptions ??= new SearchOptions();

        var result = new List<IFileInfo>();

        var stack = new Stack<string>();
        stack.Push(Path.DirectorySeparatorChar.ToString());
        
        while (stack.Count > 0)
        {
            var currentPath = stack.Pop();
            var content = fileProvider.GetDirectoryContents(currentPath);

            foreach (var fileInfo in content)
            {
                if (!fileInfo.Exists)
                {
                    continue;
                }
                
                if (searchOptions.IsRecursive && fileInfo.IsDirectory)
                {
                    stack.Push(Path.Combine(currentPath, fileInfo.Name));
                }

                if (criteria.IsMatch(fileInfo, searchOptions))
                {
                    result.Add(fileInfo);
                }
            }
        }

        return result;
    }
}