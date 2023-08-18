namespace LeetCode.Core.Parsers;

internal class BoolValueParser : ValueParserBase<bool?>
{
    public override bool TryParse(ReadOnlySpan<char> input, out bool? result)
    {
        result = default;

        if (input.Length == 0)
        {
            return false;
        }

        var temp = input.Trim(' ');
        if (temp.Equals("null", StringComparison.InvariantCultureIgnoreCase))
        {
            return true;
        }

        if (temp.Equals("true", StringComparison.InvariantCultureIgnoreCase))
        {
            result = true;
            return true;
        }

        if (temp.Equals("false", StringComparison.InvariantCultureIgnoreCase))
        {
            result = false;
            return true;
        }

        return false;
    }
}
