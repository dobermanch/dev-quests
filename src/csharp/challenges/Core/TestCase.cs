using System.Collections;
using System.Diagnostics;

namespace LeetCode.Core;

[DebuggerDisplay("{Name} Params({_data.Count - 1})")]
public class TestCase : IEnumerable<object?>
{
    private readonly List<object?> _data;
    private bool _resultAdded;

    public TestCase(IEnumerable<object?>? data)
    {
        _data = data?.ToList() ?? throw new ArgumentNullException(nameof(data));
    }

    public TestCase(string name, bool skip)
    {
        _data = [name ?? throw new ArgumentNullException(nameof(name))];
        Skip = skip;
    }

    public string Name
    {
        get => (string)_data[0]!;
        set => _data[0] = value;
    }

    public object?[] Params => _data.Skip(2).ToArray();

    public object? Output => _data.Count > 1 ? _data[1] : null;

    public bool Skip { get; private init; }

    public bool IsParamsParsed { get; private set; }

    public bool IsResultParsed { get; private set; }

    public TestCase Param<T>(T? param, bool isParsed = false)
    {
        IsParamsParsed = isParsed;
        _data.Add(param);
        return this;
    }

    public TestCase Result<T>(T result, bool isParsed = false)
    {
        if (_resultAdded)
        {
            throw new ArgumentException("Result already added");
        }

        IsResultParsed = isParsed;
        _resultAdded = true;
        _data.Insert(1, result);

        return this;
    }

    public TestCase Clone()
        => new(_data.Select(it =>
        {
            if (it is ICloneable cloneable)
            {
                return cloneable.Clone();
            }

            return it;
        }))
        {
            Skip = Skip,
            IsParamsParsed = IsParamsParsed,
            IsResultParsed = IsResultParsed
        };

    IEnumerator<object?> IEnumerable<object?>.GetEnumerator()
        => _data.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
        => ((IEnumerable<object?>)this).GetEnumerator();
}
