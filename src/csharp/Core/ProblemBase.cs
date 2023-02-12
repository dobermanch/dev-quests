using System.Reflection;

namespace LeetCode.Core;

public abstract class ProblemBase: TestCaseCollection
{
    private static readonly IDictionary<Type, IDictionary<string, MethodInfo>> _map = new Dictionary<Type, IDictionary<string, MethodInfo>>();

    public virtual void Test(object[] data)
    {
        if (!_map.TryGetValue(GetType(), out var solutions))
        {
            _map.Add(GetType(), solutions = new Dictionary<string, MethodInfo>());
        }

        if (!solutions.TryGetValue((string) data[0], out var method))
        {
            method = GetType()
                .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(it => it.Name.Equals((string) data[0]));

            if (method == null)
            {
                throw new ArgumentException($"The '{data[0]}' method is not found.");
            }

            solutions.Add(method.Name, method);
        }

        var result = method.Invoke(this, data.Skip(2).ToArray());
        //if (result is IEnumerable<object> received 
        //    && data[0] is IEnumerable<object> expected)
        //{
        //    Assert.True(expected.SequenceEqual(received));
        //}
        //else
        //{
        Assert.Equal(data[1], result);
        //}
    }

    public virtual void AddTestCases() { }

    public override IEnumerator<object[]> GetEnumerator()
    {
        AddTestCases();

        return base.GetEnumerator();
    }
}