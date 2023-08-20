namespace LeetCode.Core.Parsers;

internal class StringTo2dArrayParser<TOut> : IDataParser<string, IList<IList<TOut>>>
{
    private readonly StringToArrayParser<TOut> _valueParser;
    private readonly bool _allowEmpty;

    public StringTo2dArrayParser(ValueParserBase<TOut> valueParser, bool allowEmpty = true)
    {
        _valueParser = new StringToArrayParser<TOut>(valueParser);
        _allowEmpty = allowEmpty;
    }

    public IList<IList<TOut>> Parse(string input)
    {
        if (TryParse(input, out var result))
        {
            return result;
        }

        throw new InvalidOperationException($"Failed to parse '{input}'.");
    }

    public virtual bool TryParse(string input, out IList<IList<TOut>> result)
    {
        if (input is null)
        {
            result = Array.Empty<IList<TOut>>();
            return true;
        }

        try
        {
            result = new List<IList<TOut>>();
            var stack = new Stack<char>();
            var startIndex = 0;

            var data = input.AsSpan();
            for (var index = 0; index < data.Length; index++)
            {
                var ch = data[index];
                if (ch is '[' or '{')
                {
                    stack.Push(ch);
                    startIndex = index;
                }
                else if ((ch is ']' && stack.Peek() is '[') || (ch is '}' && stack.Peek() is '{'))
                {
                    stack.Pop();

                    if (_valueParser.TryParse(data[startIndex..(index + 1)].ToString(), out var value))
                    {
                        if (value.Count > 0 || _allowEmpty)
                        {
                            result.Add(value!);
                        }
                    }

                    startIndex = index + 1;
                }
            }

            return true;
        }
        catch
        {
            result = Array.Empty<IList<TOut>>();
            return false;
        }
    }
}
 