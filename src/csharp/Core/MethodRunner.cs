using System.Reflection;

namespace LeetCode.Core;

internal class MethodRunner : ITestRunner
{
    private readonly IDictionary<string, MethodInfo> _map;
    private readonly object _testClass;

    public MethodRunner(object testClass)
    {
        _map = GetSolutions(testClass.GetType());
        _testClass = testClass;
    }

    public IReadOnlyCollection<string> Targets => _map.Keys.ToArray().AsReadOnly();

    public void Run(TestCase testCase)
    {
        if (!_map.TryGetValue(testCase.Name, out var method))
        {
            throw new ArgumentException($"The '{testCase.Name}' method is not found.");
        }

        //TODO: Deep clone test input data, because it can be modified in the previous test
        var result = method.Invoke(_testClass, testCase.Params);
        Assert.Equal(testCase.Output, result, new ObjectComparer());
    }

    private static IDictionary<string, MethodInfo> GetSolutions(Type testClass)
    {
        return testClass
            .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
            .Where(it => it.Name.StartsWith("Solution"))
            .ToDictionary(it => it.Name, it => it);
    }
}
