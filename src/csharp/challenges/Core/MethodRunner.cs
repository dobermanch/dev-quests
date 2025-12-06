using System.Collections.Immutable;
using System.Reflection;

namespace LeetCode.Core;

internal class MethodRunner : TestRunnerBase
{
    private readonly object _testClass;
    private readonly IDictionary<string, MethodInfo> _map;

    public MethodRunner(object testClass)
    {
        _testClass = testClass;
        var targets = GetSolutions(testClass.GetType());
        if (targets.Count == 0)
        {
            throw new ArgumentException($"The 'Solution' methods not found in the '{_testClass.GetType().Name}' class.");
        }

        var method = targets.First();
        ArgumentTypes = method.GetParameters().Select(it => it.ParameterType).ToArray();
        OutputType = method.ReturnType;
        Targets = targets.Select(it => it.Name).ToArray();
        _map = targets.ToDictionary(it => it.Name, it => it);
    }

    public Type OutputType { get; }

    public Type[] ArgumentTypes { get; }

    public override void Run(TestCase testCase)
    {
        if (!_map.TryGetValue(testCase.Name, out var method))
        {
            throw new ArgumentException($"The '{testCase.Name}' method is not found.");
        }

        //TODO: Deep clone test input data, because it can be modified in the previous test
        var result = method.Invoke(_testClass, testCase.Params);
        Assert.Equal(testCase.Output, result, new ObjectComparer());
    }

    private static ImmutableList<MethodInfo> GetSolutions(Type testClass)
        => testClass
            .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
            .Where(it => it.Name.StartsWith("Solution"))
            .ToImmutableList();
}
