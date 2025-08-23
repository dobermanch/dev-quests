namespace LeetCode.Core.Parsers;

internal class DoubleValueParser : ValueParserBase
{
    public override bool TryParse(ReadOnlySpan<char> input, out object result)
    {
        result = null!;

        if (input.Length == 0)
        {
            return false;
        }

        var temp = input.Trim(' ');
        if (temp.Length == 0 || temp.Equals("null", StringComparison.InvariantCultureIgnoreCase))
        {
            return true;
        }

        if (double.TryParse(temp.Trim('"').ToString(), out var result1))
        {
            result = result1;
            return true;
        }

        return false;
    }
}
