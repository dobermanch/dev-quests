namespace LeetCode.Core.Parsers;

internal interface IDataParser<TIn, TOut>
{
    bool TryParse(TIn input, out TOut result);
}
