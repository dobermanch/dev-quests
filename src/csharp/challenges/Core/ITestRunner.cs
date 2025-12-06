namespace LeetCode.Core;

public interface ITestRunner
{
    IReadOnlyCollection<string> Targets { get; }

    void Run(TestCase testCase);
}

public abstract class TestRunnerBase : TestCaseCollection, ITestRunner
{
    public IReadOnlyCollection<string> Targets { get; protected set; }

    public abstract void Run(TestCase testCase);
}
