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

    public TestCaseCollection Add(Action<TestCase> configure, bool skip = false)
    {
        if (!skip)
        {
            var testCase = TestCase.Create("<Default>");
            configure(testCase);
            _data.Add(testCase);
        }

        return this;
    }

    public virtual IEnumerator<TestCase> GetEnumerator() 
        => _data.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
        => ((IEnumerable<TestCase>)this).GetEnumerator();
}