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
            else if (char.IsLetter(ch))
            {
                literal += ch;
            }
            else if (ch is ',' or ']' or '}' && (number != null || "null".Equals(literal, StringComparison.InvariantCultureIgnoreCase)))
            {
                row.Add(number);
                number = null;
            }
        }

        return row.ToArray();
    }
}