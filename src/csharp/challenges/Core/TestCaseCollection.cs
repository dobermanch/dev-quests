using System.Collections;

namespace LeetCode.Core;

public class TestCaseCollection : IEnumerable<TestCase>
{
    private readonly IList<TestCase> _data = new List<TestCase>();

    public TestCaseCollection Add(TestCase testCase)
    {
        _data.Add(testCase);
        return this;
    }

    public TestCaseCollection Add(bool skip, Action<TestCase> configure)
    {
        var testCase = new TestCase("<Default>", skip);
        configure(testCase);
        _data.Add(testCase);

        return this;
    }

    public TestCaseCollection Add(Action<TestCase> configure)
        => Add(false, configure);

    public void Clear() => _data.Clear();

    public IEnumerator<TestCase> GetEnumerator()
        => _data.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
        => ((IEnumerable<TestCase>)this).GetEnumerator();
}
