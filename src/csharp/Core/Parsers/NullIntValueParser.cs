namespace LeetCode.Core.Parsers;

internal class NullIntValueParser : ValueParserBase<int?>
{
    private readonly bool _failIfCannotParse;

    public NullIntValueParser(bool failIfCannotParse = true)
    {
        _failIfCannotParse = failIfCannotParse;
    }

    public override bool TryParse(ReadOnlySpan<char> input, out int? result)
    {
        result = null;

        if (input.Length == 0)
        {
            return false;
        }

        var temp = input.Trim(' ');
        if (temp.Length == 0 || temp.Equals("null", StringComparison.InvariantCultureIgnoreCase))
        {
            return true;
        }

        if (int.TryParse(temp.Trim('"').ToString(), out var result1))
        {
            result = result1;
            return true;
        }

        if (_failIfCannotParse)
        {
            throw new InvalidOperationException($"Cannot parse '{input}'");
        }

        return false;
    }
}
