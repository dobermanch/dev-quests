namespace LeetCode.Core.Parsers;

internal class StringValueParser : ValueParserBase
{
    public override bool TryParse(ReadOnlySpan<char> input, out object result)
    {
        result = default;

        if (input.Length == 0)
        {
            return false;
        }

        var temp = input.Trim(' ');
        if (input.Length != 0 && !temp.Equals("null", StringComparison.InvariantCultureIgnoreCase))
        {
            if (temp.Length <= 0) 
            { 
                result = string.Empty;
                return true;
            }

            if (temp[0] != '\"' && temp[^1] != '\"')
            {
                return false;
            }

            result = temp[1..^1].ToString().Replace("\\\"", "\"");
        }

        return true;
    }
}
