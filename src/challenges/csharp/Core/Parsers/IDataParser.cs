namespace LeetCode.Core.Parsers;

internal interface IDataParser<TOut>
{
    bool TryParse(ReadOnlySpan<char> input, out TOut result);
}
