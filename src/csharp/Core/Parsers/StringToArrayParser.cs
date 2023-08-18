namespace LeetCode.Core.Parsers;

internal class StringToArrayParser<TOut> : IDataParser<string, IList<TOut>>
{
    private readonly ValueParserBase<TOut> _valueParser;

    public StringToArrayParser(ValueParserBase<TOut> valueParser)
    {
        _valueParser = valueParser;
    }

    public IList<TOut> Parse(string input)
    {
        if (TryParse(input, out var result))
        {
            return result;
        }

        throw new InvalidOperationException($"Failed to parse '{input}'.");
    }

    public virtual bool TryParse(string input, out IList<TOut> result)
    {
        if (input is null)
        {
            result = Array.Empty<TOut>();
            return true;
        }

        try
        {
            result = new List<TOut>();
            var stack = new Stack<char>();
            var startIndex = 0;

            var data = input.AsSpan();
            for (var index = 0; index < data.Length; index++)
            {
                var ch = data[index];
                if (ch is '[' or '{')
                {
                    stack.Push(ch);
                    startIndex = index + 1;
                }
                else if ((ch is ']' && stack.Peek() is '[') || (ch is '}' && stack.Peek() is '{'))
                {
                    stack.Pop();
                    if (_valueParser.TryParse(data.Slice(startIndex, index - startIndex), out var value))
                    {
                        result.Add(value!);
                    }
                    startIndex = index + 1;
                }
                else if (ch is '"')
                {
                    if (input[index - 1] != '\\' && stack.Peek() is '"')
                    {
                        stack.Pop();
                    }
                    else if (input[index - 1] != '\\')
                    {
                        stack.Push(ch);
                    }
                }
                else if (ch is ',' && stack.Peek() is not '"' or '\'')
                {
                    if (_valueParser.TryParse(data.Slice(startIndex, index - startIndex), out var value))
                    {
                        result.Add(value);
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
