namespace LeetCode.Core.Parsers;

internal class StringValueParser : ValueParserBase<string>
{
    public override bool TryParse(ReadOnlySpan<char> input, out string result)
    {
        result = default;

        if (input.Length == 0)
        {
            return false;
        }

        var temp = input.Trim(' ');
        if (input.Length != 0 && !temp.Equals("null", StringComparison.InvariantCultureIgnoreCase))
        {
            result = temp.Trim('"').ToString();
        }

        return true;
    }
}
