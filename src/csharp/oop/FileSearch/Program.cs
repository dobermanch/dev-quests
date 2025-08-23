using FileSearch;
using FileSearch.Search;
using FileSearch.Search.Attributes;
using FileSearch.Search.Operands;

Console.WriteLine($"Args: {args[0]}");

var criteria = new AndOperand([
    new OrOperand([
        new ByNameMatchCriteria("Program"),
        new ByNameMatchCriteria("readme"),
    ]),
]);

var result = new SearchEngine(args[0]).Search(criteria, new SearchOptions
{
    IsRecursive = true,
    IsCaseSensitive = false
}).ToArray();

Console.WriteLine($"Found files: {result.Length}");

foreach (var file in result)
{
    Console.WriteLine($"  {file.Name}");
}
