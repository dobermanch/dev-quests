namespace LeetCode.Core.Parsers;

internal class CharValueParser : ValueParserBase<char?>
{
    public override bool TryParse(ReadOnlySpan<char> input, out char? result)
    {
        result = default;

        if (input.Length == 0)
        {
            return false;
        }

        var temp = input.Trim(' ');
        if (input.Length != 0 && !temp.Equals("null", StringComparison.InvariantCultureIgnoreCase))
        {
            if ((temp[0] != '\'' && temp[^1] != '\'') && (temp[0] != '"' && temp[^1] != '"'))
            {
                return false;
            }

            temp = temp[1..^1];
            if (temp[0] == '\\')
            {
                temp = temp[1..];
            }

            if (temp.Length > 1)
            {
                return false;
            }

            result = temp[0];
        }

        return true;
    }
}
