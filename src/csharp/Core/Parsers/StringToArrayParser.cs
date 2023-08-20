namespace LeetCode.Core.Parsers;

internal class StringToArrayParser<TOut> : IDataParser<IList<TOut>>
{
    private readonly ValueParserBase _valueParser;

    public StringToArrayParser()
    {
        _valueParser = typeof(TOut) switch
        {
            Type type when type == typeof(int) || type == typeof(int?) => new IntValueParser(),
            Type type when type == typeof(char) || type == typeof(char?) => new CharValueParser(),
            Type type when type == typeof(bool) || type == typeof(bool?) => new BoolValueParser(),
            Type type when type == typeof(string) => new StringValueParser(),
            Type type when type == typeof(object) => new ObjectValueParser(),
            _ => throw new ArgumentException($"The '{typeof(TOut)}' is not supported.")
        };
    }

    public IList<TOut> Parse(string input)
    {
        if (TryParse(input, out var result))
        {
            return result;
        }

        throw new InvalidOperationException($"Failed to parse '{input}'.");
    }

    public virtual bool TryParse(ReadOnlySpan<char> input, out IList<TOut> result)
    {
        try
        {
            result = new List<TOut>();
            var stack = new Stack<char>();
            var startIndex = 0;

            for (var index = 0; index < input.Length; index++)
            {
                var ch = input[index];
                if (ch is '[' or '{')
                {
                    stack.Push(ch);
                    startIndex = index + 1;
                }
                else if ((ch is ']' && stack.Peek() is '[') || (ch is '}' && stack.Peek() is '{'))
                {
                    stack.Pop();
                    if (_valueParser.TryParse(input.Slice(startIndex, index - startIndex), out var value))
                    {
                        result.Add((TOut)value);
                    }
                    startIndex = index + 1;
                }
                else if (ch is '"' or '\'')
                {
                    if (input[index - 1] != '\\' && stack.Peek() == ch)
                    {
                        stack.Pop();
                    }
                    else if (input[index - 1] != '\\')
                    {
                        stack.Push(ch);
                    }
                }
                else if (ch is ',' && stack.Peek() is not '"' and not '\'')
                {
                    if (_valueParser.TryParse(input.Slice(startIndex, index - startIndex), out var value))
                    {
                        result.Add((TOut)value);
                    }

                    startIndex = index + 1;
                }
            }

            return true;
        }
        catch
        {
            result = Array.Empty<TOut>();
            return false;
        }
    }
}
