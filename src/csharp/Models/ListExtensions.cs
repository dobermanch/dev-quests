using LeetCode.Core.Parsers;

namespace LeetCode.Models;

internal static class ListExtensions
{
    public static TOut[] ToArray<TOut>(this string? input)
    {
        var parser = new StringToArrayParser<TOut>();

        return parser.Parse(input).ToArray();
    }

    public static TOut[][] To2dArray<TOut>(this string? input, bool allowEmpty = true)
    {
        var parser = new StringTo2dArrayParser<TOut>(allowEmpty);

        return parser.Parse(input).Select(it => it.ToArray()).ToArray();
    }
}