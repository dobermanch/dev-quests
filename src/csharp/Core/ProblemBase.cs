using System.Reflection;

namespace LeetCode.Core;

public abstract class ProblemBase: TestCaseCollection
{
    private static readonly IDictionary<Type, MethodInfo[]> _map = new Dictionary<Type, MethodInfo[]>();

    public virtual void Test(object[] data)
    {
        if (!_map.TryGetValue(GetType(), out var solutions))
        {
            solutions = GetType()
                .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(it => it.Name.StartsWith("Solution")).ToArray();

            if (!solutions.Any())
            {
                throw new ArgumentException("The 'Solution' method is not found. All solutions should start with 'Solution' word.");
            }

            _map.Add(GetType(), solutions);
        }

        foreach (var solution in solutions!)
        {
            var result = solution.Invoke(this, data.Skip(1).ToArray());
            if (result is IEnumerable<object> received 
                && data[0] is IEnumerable<object> expected)
            {
                Assert.True(expected.SequenceEqual(received));
            }
            else
            {
                Assert.Equal(data[0], result);
            }
        }
    }

    public virtual void AddTestCases() { }

    public override IEnumerator<object[]> GetEnumerator()
    {
        AddTestCases();

        return base.GetEnumerator();
    }
}