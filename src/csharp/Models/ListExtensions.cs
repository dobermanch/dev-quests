using System.Collections.Immutable;

namespace LeetCode.Models;

internal static class ListExtensions
{
    public static int[] ToArray(this string? input) 
        => input.ToNullableArray().Where(it => it != null).Select(it => (int)it!).ToArray();

    public static int?[] ToNullableArray(this string? input)
    {
        if (input == null)
        {
            return Array.Empty<int?>();
        }

        var data = input.Trim();

        var row = new List<int?>();
        int? number = null;
        bool negative = false;
        string? literal = null;
        foreach (var ch in data.Where(ch => ch != ' '))
        {
            if (ch is '[' or '{')
            {
                // leave it
            }
            else if (char.IsDigit(ch))
            {
                number ??= 0;
                number *= 10;
                number += ch - '0';
            }
            else if (ch == '-')
            {
                negative = true;
            }
            else if (char.IsLetter(ch))
            {
                literal += ch;
            }
            else if (ch is ',' or ']' or '}' && (number != null || "null".Equals(literal, StringComparison.InvariantCultureIgnoreCase)))
            {
                row.Add(negative ? -number : number);
                number = null;
                literal = null;
                negative = false;
            }
        }

        return row.ToArray();
    }

    public static T[][] To2dArray<T>(this string? input, bool allowEmpty = true)
    {
        if (input == null)
        {
            return Array.Empty<T[]>();
        }

        var data = input.Trim();
        var matrix = new List<object[]>();

        List<object>? row = null;
        int? number = null;
        string? literal = null;
        bool negative = false;
        foreach (var ch in data)
        {
            if (ch == ' ')
            {
                continue;
            }

            if (ch is '[' or '{')
            {
                row = new List<object>();
            }
            else if (char.IsDigit(ch))
            {
                number ??= 0;
                number *= 10;
                number += ch - '0';
            }
            else if (char.IsLetter(ch))
            {
                literal += ch;
            }
            else if (ch == '-')
            {
                negative = true;
            }
            else if (ch is ',' && row != null)
            {
                if (number != null)
                {
                    row.Add(negative ? -number.Value : number.Value);
                    number = null;
                    negative = false;
                }

                AddLiteral<T>(literal, row);
                literal = null;
            }
            else if (ch is ']' or '}' && row != null)
            {
                if (number != null)
                {
                    row.Add(negative ? -number.Value : number.Value);
                    number = null;
                    negative = false;
                }

                AddLiteral<T>(literal, row);
                literal = null;

                if (allowEmpty || row.Any())
                {
                    matrix.Add(row.ToArray());
                    row = null;
                }
            }
        }

        return matrix.Select(it => it.Select(x => (T)x).ToArray()).ToArray();
    }

    private static void AddLiteral<T>(string? literal, List<object> row)
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
}