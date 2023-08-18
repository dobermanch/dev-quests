using System.Collections;
using System.Diagnostics;

namespace LeetCode.Core;

[DebuggerDisplay("{Name} Params({_data.Count - 1})")]
public class TestCase : IEnumerable<object>
{
    private readonly IList<object> _data;
    private bool _resultAdded;

    protected TestCase(string name) 
        : this(name, new List<object>()) { }

    protected TestCase(string name, IList<object> data)
    {
        _data = data;
        if (!data.Any())
        {
            _data.Insert(0, name);
        }
        else
        {
            _data[0] = name;
        }
    }

    public string Name
    {
        get => (string)_data[0];
        set => _data[0] = value;
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

    public TestCase Clone(string methodName) => new(methodName, _data.ToList());

    public static TestCase Create(string methodName) => new(methodName);

    IEnumerator<object> IEnumerable<object>.GetEnumerator() => _data.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<object>)this).GetEnumerator();
}