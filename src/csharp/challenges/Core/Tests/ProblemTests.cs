namespace LeetCode.Core.Tests;

public sealed class ProblemTests : ProblemBase
{
    private readonly string _param1 = "10";
    private readonly int _param2 = 12;
    private readonly int[] _param3 = new[] { 1, 2, 3 };
    private readonly bool _result = true;

    [Theory]
    [ClassData(typeof(ProblemTests))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param(_param1).Param(_param2).Param(_param3.ToArray()).Result(_result))
          .Add(it => it.Param(_param1).Param(_param2).Param(_param3.ToArray()).Result(_result));

    private bool Solution(string param1, int param2, int[] param3)
    {
        Assert.Equal(param1, _param1);
        Assert.Equal(param2, _param2);
        Assert.True(param3.SequenceEqual(_param3));

        return _result;
    }

    private bool Solution1(string param1, int param2, int[] param3)
    {
        Assert.Equal(param1, _param1);
        Assert.Equal(param2, _param2);
        Assert.True(param3.SequenceEqual(_param3));

        return _result;
    }

    private bool CustomSolution(string param1, int param2, int[] param3)
    {
        Assert.Equal(param1, _param1);
        Assert.Equal(param2, _param2);
        Assert.True(param3.SequenceEqual(_param3));

        return _result;
    }
}