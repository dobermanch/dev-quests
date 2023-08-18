using LeetCode.Core.Parsers;

namespace LeetCode.Models;

internal static class ListExtensions
{
    public static int[] ToArray(this string? input)
    {
        var parser = new StringToArrayParser<int>(new IntValueParser());

        return parser.Parse(input).ToArray();
    }

    public static int?[] ToNullableArray(this string input)
    {
        var parser = new StringToArrayParser<int?>(new NullIntValueParser());

        return parser.Parse(input).ToArray();
    }

    public static TOut[][] To2dArray<TOut>(this string? input, Converter<object, TOut>? converter = null, bool allowEmpty = true)
    {
        if (input == null)
        {
            return Array.Empty<TOut[]>();
        }

        var data = input.Trim();
        var matrix = new List<object[]>();

        List<object>? row = null;
        int? number = null;
        string? literal = null;
        bool negative = false;
        foreach (var ch in data)
        {
            if (ch is ' ' or '"' or '\'' or '\r' or '\n')
            {
                continue;
            }

            if (ch is '[' or '{')
            {
                row = new List<object>();
            }
            else if (literal is null && char.IsDigit(ch))
            {
                number ??= 0;
                number *= 10;
                number += ch - '0';
            }
            else if (ch == '-')
            {
                negative = true;
            }
            else if (ch is ',')
            {
                if (row != null)
                {
                    if (number != null)
                    {
                        row.Add(negative ? -number.Value : number.Value);
                        number = null;
                        negative = false;
                    }

                    AddLiteral(literal, row);
                    literal = null;
                }
            }
            else if (ch is ']' or '}' && row != null)
            {
                if (number != null)
                {
                    row.Add(negative ? -number.Value : number.Value);
                    number = null;
                    negative = false;
                }

                AddLiteral(literal, row);
                literal = null;

                if (allowEmpty || row.Any())
                {
                    matrix.Add(row.ToArray());
                    row = null;
                }
            }
            else
            {
                if (number is not null)
                {
                    literal += number;
                    number = null;
                }

                literal += ch;
            }
        }

        converter ??= GetConverter<TOut>();

        return matrix.Select(it => it.Select(it =>
        {
            if (converter != null)
            {
                var d =  converter(it);
                return d;
            }

            return (TOut) it;
        }).ToArray()).ToArray();
    }

    private static void AddLiteral(string? literal, List<object> row)
    {
        if ("null".Equals(literal, StringComparison.InvariantCultureIgnoreCase))
        {
            row.Add(null);
        }
        else if ("true".Equals(literal, StringComparison.InvariantCultureIgnoreCase))
        {
            row.Add(true);
        }
        else if ("false".Equals(literal, StringComparison.InvariantCultureIgnoreCase))
        {
            row.Add(true);
        }
        else if (literal != null)
        {
            row.Add(literal);
        }
    }

    private static Converter<object, T>? GetConverter<T>()
    {
        if (typeof(T) == typeof(char))
        {
            return it => it is int input
                ? (T) Convert.ChangeType(input + '0', typeof(T))
                : (T) Convert.ChangeType(it, typeof(T));
        }

        if (typeof(T) == typeof(string))
        {
            return it => (T) (object) it.ToString();
        }

        return null;
    }
}