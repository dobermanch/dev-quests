namespace LeetCode.Core.Parsers;

internal class ObjectValueParser : ValueParserBase
{
    private ValueParserBase[] _parser = new ValueParserBase[]
    {
        new CharValueParser(),
        new IntValueParser(),
        new BoolValueParser(),
        new StringValueParser(),
    };

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

        foreach(var parser in _parser)
        {
            if (parser.TryParse(temp, out var value))
            {
                result = value;
                return true;
            }
        }

        return false;
    }
}
