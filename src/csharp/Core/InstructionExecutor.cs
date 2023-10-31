namespace LeetCode.Core;

public class Instructions<T, TValue>
    where T : class, new()
{
    private readonly Dictionary<string, InstructionExecutor<T, TValue>> _map = new();

    public IReadOnlyDictionary<string, InstructionExecutor<T, TValue>> Map => _map;

    public Instructions<T, TValue> MapConstructor(string map)
    {
        _map.Add(map, new InstructionExecutor<T, TValue>());
        return this;
    }

    public Instructions<T, TValue> MapInstruction(string map, Action<T> action)
    {
        _map.Add(map, new InstructionExecutor<T, TValue>(action));
        return this;
    }

    public Instructions<T, TValue> MapInstruction(string map, Action<T, TValue> action)
    {
        _map.Add(map, new InstructionExecutor<T, TValue>(action));
        return this;
    }

    public Instructions<T, TValue> MapInstruction(string map, Func<T, TValue, object> action)
    {
        _map.Add(map, new InstructionExecutor<T, TValue>(action));
        return this;
    }

    public Instructions<T, TValue> MapInstruction(string map, Func<T, object> action)
    {
        _map.Add(map, new InstructionExecutor<T, TValue>(action));
        return this;
    }
}

public class InstructionExecutor<T, TValue>
{
    private readonly Func<T, TValue, object> _action;

    public InstructionExecutor()
    : this((obj, value) => null!) { }

    public InstructionExecutor(Func<T, object> action)
        : this((obj, value) => action(obj)) { }

    public InstructionExecutor(Action<T, TValue> action)
        : this((obj, value) => { action(obj, value); return null!; }) { }

    public InstructionExecutor(Action<T> action)
        : this((obj, value) => { action(obj); return null!; }) { }

    public InstructionExecutor(Func<T, TValue, object> action)
    {
        _action = action;
    }

    public object Execute(T obj, TValue value)
        => _action(obj, value);
}

internal class InstructionsRunner<T, TData> : ITestRunner
    where T : class, new()
{
    public Instructions<T, TData> Instructions { get; } = new Instructions<T, TData>();

    public IReadOnlyCollection<string> Targets { get; } = new[] { typeof(T).Name }.AsReadOnly();

    public void Run(TestCase testCase)
    {
        var result = new List<object>();

        var obj = new T();
        var instructions = (string[])testCase.Params[1];
        var data = (TData[])testCase.Params[0];
        for (int i = 0; i < instructions.Length ; i++)
        {
            result.Add(Instructions.Map[instructions[i]].Execute(obj, data[i]));
        }

        Assert.Equal(testCase.Output, result, new ObjectComparer());
    }
}
