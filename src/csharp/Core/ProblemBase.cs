using System.Collections;
using System.Collections.Concurrent;

namespace LeetCode.Core;

/// <summary>
/// Usage template.
/// This template can be used in VS Code and Visual Studio.And provide the most conviniant tests run support.
/// - To add new test case use <c>Add</c> method.
///     - The parameters order in the test case matches with parametes order in <c>Solution</c> method(s).
/// - You may have more then one solution. By default all solution methods should start with <c>Solution</c> word.
///     - You may add a custom solution name using <c>AddSolution</c> method.
/// <code>
/// public sealed class ProblemName : ProblemBase
/// {
///    [Theory]
///    [ClassData(typeof(ProblemName))]
///    public override void Test(object[] data) => base.Test(data);
///
///    protected override void AddTestCases()
///        => Add(it => it.Param("10").Param("12").Result("22"));
///
///    private string Solution(string num1, string num2)
///    {
///        /// Your solution
///    }
/// }
/// </code>
/// </summary>
public abstract class ProblemBase : IEnumerable<object[]>
{
    private static readonly ConcurrentDictionary<Type, ITestRunner> _runners = new();
    private readonly TestCaseCollection _testCases = new();
    private ITestRunner _runner = null!;

    public ProblemBase()
    {
        _runner = new MethodRunner(this);
    }

    public virtual void Test(object[] data)
    {
        _runners[GetType()].Run(new TestCase(data));
    }

    protected abstract void AddTestCases();

    protected TestCaseCollection Add(Action<TestCase> configure) => _testCases.Add(configure);

    protected TestCaseCollection Add(bool skip, Action<TestCase> configure) => _testCases.Add(skip, configure);

    protected TestCaseCollection Instructions<T, TValue>(Action<Instructions<T, TValue>> configure)
         where T : class, new()
    {
        var runner = new InstructionsRunner<T, TValue>();
        configure(runner.Instructions);

        _runner = runner;

        return _testCases;
    }

    public IEnumerator<object[]> GetEnumerator()
    {
        AddTestCases();

        _runners.TryAdd(GetType(), _runner);

        if (_runner.Targets.Count <= 0)
        {
            throw new InvalidOperationException($"No solution methods found. Add method that start from 'Solution'.");
        }

        var target = _runner.Targets.First();
        foreach (var testCase in _testCases)
        {
            testCase.Name = target;
        }

        var testCases = _testCases.ToArray();
        foreach (var solution in _runner.Targets.Skip(1))
        {
            foreach (var testCase in testCases)
            {
                _testCases.Add(testCase.Clone(solution));
            }
        }

        return _testCases.Select(testCase => new object[] { testCase }).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
        => ((IEnumerable<object[]>)this).GetEnumerator();
}

/// <summary>
/// Usage template.
/// This template only conviniant for Visual Studio,
/// because tests can be run via context menu or test explorer.
/// <code>
/// public sealed class ProblemName : ProblemBase<ProblemName>
/// {
///    protected override void AddTestCases()
///        => Add(it => it.Param("10").Param("12").Result("22"));
///
///    private string Solution(string num1, string num2)
///    {
///        /// Your solution
///    }
///}
/// </code>
/// </summary>
public abstract class ProblemBase<TTestClass> : ProblemBase
{
    [Theory]
    [MemberData(nameof(GetTestCases))]
    public override void Test(object[] data) => base.Test(data);

    public static IEnumerable<object[]> GetTestCases()
        => (IEnumerable<object[]>)Activator.CreateInstance(typeof(TTestClass))!;
}
