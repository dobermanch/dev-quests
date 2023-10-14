using System.Collections;
using System.Reflection;

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
///    public override void AddTestCases()
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
    private static readonly Dictionary<Type, Dictionary<string, MethodInfo>> _map = new();
    private readonly TestCaseCollection _testCases = new();
    private readonly List<string> _solutions = new();

    public virtual void Test(object[] data)
    {
        if (!_map.TryGetValue(GetType(), out var solutions))
        {
            _map.Add(GetType(), solutions = new Dictionary<string, MethodInfo>());
        }

        if (!solutions.TryGetValue((string)data[0], out var method))
        {
            method = GetType()
                .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(it => it.Name.Equals((string)data[0]));

            if (method == null)
            {
                throw new ArgumentException($"The '{data[0]}' method is not found.");
            }

            solutions.Add(method.Name, method);
        }

        //TODO: Deep clone test input data, because it can be modified in the previous test
        var result = method.Invoke(this, data.Skip(2).ToArray());
        Assert.Equal(data[1], result, new ObjectComparer());
    }

    public abstract void AddTestCases();

    protected TestCaseCollection Add(Action<TestCase> configure) => _testCases.Add(configure);

    protected TestCaseCollection Add(bool skip, Action<TestCase> configure) => _testCases.Add(skip, configure);

    protected TestCaseCollection AddSolutions(params string[] solutionMethodNames)
    {
        foreach (var methodName in solutionMethodNames)
        {
            if (!_solutions.Contains(methodName))
            {
                _solutions.Add(methodName);
            }
        }

        return _testCases;
    }

    public IEnumerator<object[]> GetEnumerator()
    {
        AddTestCases();

        AddSolutions(GetType()
            .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
            .Where(it => it.Name.StartsWith("Solution"))
            .Select(it => it.Name)
            .ToArray());

        if (_solutions.Count <= 0)
        {
            throw new InvalidOperationException($"No solution methods found. Add method that start from 'Solution' or call {nameof(AddSolutions)} method.");
        }

        foreach (var testCase in _testCases)
        {
            testCase.Name = _solutions[0];
        }

        var testCases = _testCases.ToArray();
        foreach (var solution in _solutions.Skip(1))
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
///    public override void AddTestCases()
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