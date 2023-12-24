//https://leetcode.com/problems/insert-delete-getrandom-o1

namespace LeetCode.Problems;

public sealed class MyRandomizedSet : ProblemBase
{
    [Theory]
    [ClassData(typeof(MyRandomizedSet))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Instructions<RandomizedSet, int[]>(config =>
                config
                    .MapConstructor("RandomizedSet")
                    .MapInstruction("insert", (it, data) => it.Insert(data[0]))
                    .MapInstruction("remove", (it, data) => it.Remove(data[0]))
                    .MapInstruction("getRandom", it => it.GetRandom())
            )
            .Add(tc =>
                  tc.Data<int>("[[],[0],[1],[0],[2],[1],[]]")
                    .Instructions("""["RandomizedSet","insert","insert","remove","insert","remove","getRandom"]""")
                    .Output("[null,true,true,true,true,true,2]")
            )
            .Add(tc =>
                  tc.Data<int>("[[], [1], [2], [2], [], [1], [2], []]")
                    .Instructions("""["RandomizedSet", "insert", "remove", "insert", "getRandom", "remove", "insert", "getRandom"]""")
                    .Output("[null, true, false, true, 2, true, false, 2]")
            );

    internal class RandomizedSet
    {
        private readonly Random _random = new Random(DateTime.Now.Millisecond);
        private readonly Dictionary<int, int> _index = new();
        private readonly List<int> _store = new();

        public bool Insert(int val)
        {
            if (_index.ContainsKey(val))
            {
                return false;
            }

            _store.Add(val);
            _index[val] = _store.Count - 1;

            return true;
        }

        public bool Remove(int val)
        {
            if (!_index.ContainsKey(val))
            {
                return false;
            }

            _store[_index[val]] = _store[^1];
            _index[_store[^1]] = _index[val];

            _store.RemoveAt(_store.Count - 1);
            _index.Remove(val);

            return true;
        }

        public int GetRandom() => _store[_random.Next(_store.Count)];
    }
}