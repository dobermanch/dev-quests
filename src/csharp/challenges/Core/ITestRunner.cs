namespace LeetCode.Core;

public interface ITestRunner
{ 
    IReadOnlyCollection<string> Targets { get; }

    void Run(TestCase testCase);
}
