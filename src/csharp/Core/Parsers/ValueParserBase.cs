namespace LeetCode.Core.Parsers;

internal abstract class ValueParserBase<TOut>
{
    public abstract bool TryParse(ReadOnlySpan<char> input, out TOut result);
}
