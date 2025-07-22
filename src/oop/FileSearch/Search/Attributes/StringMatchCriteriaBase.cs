using System.Text.RegularExpressions;

namespace FileSearch.Search.Attributes;

public abstract class StringMatchCriteriaBase(string expectedValue, bool isRegex)
    : AttributeMatchCriteriaBase<string>(expectedValue)
{
    private readonly Regex? _expression = isRegex ? new Regex(expectedValue) : null; 

    protected override bool Compare(string currentValue, string expectedValue, SearchOptions options)
    {
        if (_expression is not null)
        {
            return _expression.IsMatch(currentValue);
        }
        
        return options.IsCaseSensitive
            ? currentValue.Equals(expectedValue)
            : currentValue.Equals(expectedValue, StringComparison.CurrentCultureIgnoreCase);
    }
}