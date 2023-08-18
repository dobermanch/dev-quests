namespace LeetCode.Core.Parsers;

internal class ObjectValueParser : ValueParserBase<object?>
{
    public override bool TryParse(ReadOnlySpan<char> input, out object? result)
    {
        result = default;

        if (input.Length == 0)
        {
            return false;
        }

        var temp = input.Trim(' ');
        if (temp.Equals("null", StringComparison.InvariantCultureIgnoreCase))
        {
            result = null;
            return true;
        }

        if (new CharValueParser().TryParse(temp, out var ch))
        {
            result = ch;
            return true;
        }
        else if (new IntValueParser().TryParse(temp, out var number))
        {
            result = number;
            return true;
        }
        else if (new BoolValueParser().TryParse(temp, out var boolean))
        {
            result = boolean;
            return true;
        }
        else if (new StringValueParser().TryParse(temp, out var str))
        {
            result = str;
            return true;
        }

        return false;
    }
}
