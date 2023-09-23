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
        return skip ? this : Add(configure);     
    }

    public TestCaseCollection Add(Action<TestCase> configure)
    {
        var testCase = TestCase.Create("<Default>");
        configure(testCase);
        _data.Add(testCase);

        return this;
    }

    public virtual IEnumerator<TestCase> GetEnumerator() 
        => _data.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
        => ((IEnumerable<TestCase>)this).GetEnumerator();
}