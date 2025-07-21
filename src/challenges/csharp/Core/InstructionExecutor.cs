using System.Linq;

namespace LeetCode.Core;

public class Instructions<T, TValue>
    where T : class
{
    private readonly Dictionary<string, InstructionExecutor<T>> _map = new();

    public IReadOnlyDictionary<string, InstructionExecutor<T>> Map => _map;

    public Instructions<T, TValue> MapConstructor(string map)
    {
        _map.Add(map, new ConstructorExecutor<T>());
        return this;
    }

    public Instructions<T, TValue> MapConstructor(string map, Func<IList<TValue>, T> activator)
    {
        _map.Add(map, new ConstructorExecutor<T>((value) => activator((IList<TValue>)value)));
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

public class InstructionExecutor<T>
{
    private readonly Func<T, object, object> _action;

    public InstructionExecutor()
    : this((obj, value) => null!) { }
    
    public InstructionExecutor(Func<T, object, object> action)
    {
        _action = action;
    }

    public virtual object Execute(T obj, object value)
        => _action(obj, value);
}

public class InstructionExecutor<T, TValue> : InstructionExecutor<T>
{
    public InstructionExecutor()
    : this((obj, value) => null!) { }

    public InstructionExecutor(Func<T, object> action)
        : this((obj, value) => action(obj)) { }

    public InstructionExecutor(Action<T, TValue> action)
        : this((obj, value) => { action(obj, value); return null!; }) { }

    public InstructionExecutor(Action<T> action)
        : this((obj, value) => { action(obj); return null!; }) { }

    public InstructionExecutor(Func<T, TValue, object> action)
        : base((obj, value) => action(obj, (TValue)value)) { }
}

public class ConstructorExecutor<T> : InstructionExecutor<T>
{
    public ConstructorExecutor()
        : this((value) => (T)Activator.CreateInstance(typeof(T))!) { }

    public ConstructorExecutor(Func<object, object> action)
        : base((obj, value) => action(value)) { }
}

internal class InstructionsRunner<T, TData> : ITestRunner
    where T : class
{
    public Instructions<T, TData> Instructions { get; } = new Instructions<T, TData>();

    public IReadOnlyCollection<string> Targets { get; } = new[] { typeof(T).Name }.AsReadOnly();

    public void Run(TestCase testCase)
    {
        var result = new List<object>();

        T obj = null!;
        var instructions = (string[])testCase.Params[1]!;
        var data = ((TData[])testCase.Params[0]!).ToList();
        for (int i = 0; i < instructions.Length ; i++)
        {
            var executor = Instructions.Map[instructions[i]];
            if (executor is ConstructorExecutor<T>)
            {
                obj = (T)executor.Execute(null!, data);
                result.Add(null!);
            }
            else
            {
                result.Add(Instructions.Map[instructions[i]].Execute(obj, data[i]!));
            }
        }

        Assert.Equal(testCase.Output, result, new ObjectComparer());
    }
}
