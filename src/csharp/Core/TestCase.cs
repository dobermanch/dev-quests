using System.Collections;
using System.Diagnostics;

namespace LeetCode.Core;

[DebuggerDisplay("{Name} Params({_data.Count - 1})")]
public class TestCase : IEnumerable<object>
{
    private readonly IList<object> _data;
    private bool _resultAdded;

    public TestCase(object[] data)
    {
        _data = data ?? throw new ArgumentNullException(nameof(data));
    }

    protected TestCase(string name) 
        : this(name, null) { }

    protected TestCase(string name, IList<object>? data)
    {
        _data = data ?? new List<object>();
        if (!_data.Any())
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
        get => _data.Count > 0 ? (string)_data[0]! : throw new ArgumentNullException();
        set => _data[0] = value;
    }

    public object[] Params => _data.Skip(2).ToArray();

    public object? Output => _data.Count > 1 ?  _data[1] : null;

    public TestCase Param<T>(T? param)
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