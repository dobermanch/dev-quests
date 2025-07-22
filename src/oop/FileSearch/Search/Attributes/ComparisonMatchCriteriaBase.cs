using System.Numerics;

namespace FileSearch.Search.Attributes;

public abstract class ComparisonMatchCriteriaBase<T>(T expectedValue, ComparisonOperandType comparisonOperandType)
    : AttributeMatchCriteriaBase<T>(expectedValue) where T : INumber<T>
{
    protected override bool Compare(T currentValue, T expectedValue, SearchOptions options)
        => comparisonOperandType switch
        {
            ComparisonOperandType.Equal => currentValue == expectedValue,
            ComparisonOperandType.GreaterThan => currentValue > expectedValue,
            ComparisonOperandType.GreaterThanOrEqual => currentValue >= expectedValue,
            ComparisonOperandType.LessThan => currentValue < expectedValue,
            ComparisonOperandType.LessThanOrEqual => currentValue <= expectedValue,
            _ => false
        };
}