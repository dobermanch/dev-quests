using System.Collections;

namespace LeetCode.Core;

public class TestCase : IEnumerable<object>
{
    private readonly IList<object> _data;
    private bool _resultAdded;

    protected TestCase(string methodName) 
        : this(methodName, new List<object>()) { }

    protected TestCase(string methodName, IList<object> data)
    {
        _data = data;
        MethodName = methodName;
        if (!data.Any())
        {
            _data.Insert(0, MethodName);
        }
        else
        {
            _data[0] = MethodName;
        }
    }

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
        _data.Insert(1, result);

        return this;
    }

    public string MethodName { get; }

    public TestCase Clone(string methodName) => new(methodName, _data.ToList());

    public static TestCase Create(string methodName) => new(methodName);

    IEnumerator<object> IEnumerable<object>.GetEnumerator() => _data.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<object>)this).GetEnumerator();
}