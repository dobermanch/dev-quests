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
    private static readonly ConcurrentDictionary<Type, ITestRunner> Runners = new();
    private readonly TestCaseCollection _testCases = new();
    private ITestRunner? _runner;
    private IList<object[]>? _materializedTestCases;

    public virtual void Test(object[] data)
    {
        Runners[GetType()].Run(new TestCase(data));
    }

    protected abstract void AddTestCases();

    protected TestCaseCollection Add(Action<TestCase> configure) => _testCases.Add(configure);

    protected TestCaseCollection Add(bool skip, Action<TestCase> configure) => _testCases.Add(skip, configure);

    protected TestCaseCollection Instructions<T, TValue>(Action<Instructions<T, TValue>> configure)
         where T : class
    {
        var runner = new InstructionsRunner<T, TValue>();
        configure(runner.Instructions);

        _runner = runner;

        return _testCases;
    }

    public IEnumerator<object[]> GetEnumerator()
    {
        if (_materializedTestCases is not null)
        {
            return _materializedTestCases.GetEnumerator();
        }

        AddTestCases();

        _runner ??= new MethodRunner(this);

        Runners.TryAdd(GetType(), _runner);

        if (_runner.Targets.Count <= 0)
        {
            throw new InvalidOperationException($"No solution methods found. Add method that start from 'Solution'.");
        }

        _materializedTestCases = new List<object[]>();
        foreach (var target in _runner.Targets)
        {
            foreach (var testCase in _testCases.Where(it => !it.Skip))
            {
                var newTestCase = testCase.Clone();
                newTestCase.Name = target;
                _materializedTestCases.Add([newTestCase]);
            }
        }

        return _materializedTestCases.GetEnumerator();
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
