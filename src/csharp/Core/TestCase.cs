using System.Collections;

namespace LeetCode.Core;

public class TestCase : IEnumerable<object>
{
    private readonly IList<object> _data = new List<object>();
    private bool _resultAdded;

    protected TestCase() { }

    public TestCase Param<T>(T param)
    {
        _data.Add(param);
        return this;
    }

    public TestCase Result<T>(T result)
    {
        if (_resultAdded)
        {
            throw new ArgumentException("Result already added");
        }

        _resultAdded = true;
        _data.Insert(0, result);

        return this;
    }

    public static TestCase Create() => new();

    IEnumerator<object> IEnumerable<object>.GetEnumerator() => _data.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<object>)this).GetEnumerator();
}