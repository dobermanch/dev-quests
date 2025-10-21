
// https://leetcode.com/problems/final-value-of-variable-after-performing-operations

namespace LeetCode.Problems;

public sealed class FinalValueOfVariableAfterPerformingOperations : ProblemBase
{
    [Theory]
    [ClassData(typeof(FinalValueOfVariableAfterPerformingOperations))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamArray<string>(["--X","X++","X++"]).Result(1))
        .Add(it => it.ParamArray<string>(["++X","++X","X++"]).Result(3))
        .Add(it => it.ParamArray<string>(["X++","++X","--X","X--"]).Result(0))
        ;

    private int Solution(string[] operations)
    {
        var operationsMap = new Dictionary<string, int>
        {
            {"++X", 1},
            {"X++", 1},
            {"--X", -1},
            {"X--", -1}
        };

        var x = 0;
        foreach (var op in operations)
        {
            if (operationsMap.TryGetValue(op, out var value))
            {
                x += value;
            }
        }

        return x;
    }
}
