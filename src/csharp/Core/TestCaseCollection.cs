using System.Collections;

namespace LeetCode.Core;

public class TestCaseCollection : IEnumerable<object[]>
{
    private readonly IList<TestCase> _data = new List<TestCase>();
    private readonly IList<string> _methods = new List<string> { "Solution" };

    protected TestCaseCollection() { }

    public TestCaseCollection Add(bool skip, Action<TestCase> configure) => skip ? this : Add(configure);

    public TestCaseCollection Add(Action<TestCase> configure)
    {
        var testCase = TestCase.Create(_methods[0]);
        configure(testCase);
        _data.Add(testCase);

        foreach (var method in _methods.Skip(1))
        {
            _data.Add(testCase.Clone(method));
        }

        return this;
    }

    public TestCaseCollection AddSolutions(params string[] solutionMethodNames)
    {
        foreach (var methodName in solutionMethodNames)
        {
            if (!_methods.Contains(methodName))
            {
                _methods.Add(methodName);
            }
        }

        return this;
    }

    public virtual IEnumerator<object[]> GetEnumerator() 
        => _data.Select(testCase => new object[] { testCase }).GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
        => ((IEnumerable<object[]>)this).GetEnumerator();

    public static TestCaseCollection Create() => new();
}