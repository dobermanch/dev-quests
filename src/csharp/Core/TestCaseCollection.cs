using System.Collections;

namespace LeetCode.Core;

public class TestCaseCollection : IEnumerable<object[]>
{
    private readonly IList<TestCase> _data = new List<TestCase>();

    protected TestCaseCollection() { }

    public TestCaseCollection Add(Action<TestCase> configure)
    {
        var testCase = TestCase.Create();
        configure(testCase);
        _data.Add(testCase);
        return this;
    }

    public virtual IEnumerator<object[]> GetEnumerator() 
        => _data.Select(testCase => new object[] { testCase }).GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
        => ((IEnumerable<object[]>)this).GetEnumerator();

    public static TestCaseCollection Create() => new();
}