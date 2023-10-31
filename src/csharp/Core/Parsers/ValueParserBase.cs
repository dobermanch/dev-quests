namespace LeetCode.Core.Parsers;

internal abstract class ValueParserBase : IDataParser<object?>
{
    public virtual bool TryParse(ReadOnlySpan<char> input, out object? result)
    {
        result = default!;

        if (input.Length == 0)
        {
            return false;
        }

        var temp = input.Trim(' ');
        if (temp.Equals("null", StringComparison.InvariantCultureIgnoreCase))
        {
            return true;
        }

        return false;
    }
}