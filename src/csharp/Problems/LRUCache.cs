//https://leetcode.com/problems/lru-cache/

namespace LeetCode.Problems;

public sealed class LRUCache : ProblemBase
{
    [Theory]
    [ClassData(typeof(LRUCache))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param2dArray<int>("""[[2],[2,1],[1,1],[2,3],[4,1],[1],[2]]""", true)
                .ParamArray<string>("""["LRUCache","put","put","put","put","get","get"]""")
                .ResultArray<object?>(null, null, null, null, null, -1, 3))
          .Add(it => it.Param2dArray<int>("""[[2], [1, 1], [2, 2], [1], [3, 3], [2], [4, 4], [1], [3], [4]]""", true)
                       .ParamArray<string>("""["LRUCache", "put", "put", "get", "put", "get", "put", "get", "get", "get"]""")
                       .ResultArray<object?>(null, null, null, 1, null, -1, null, -1, 3, 4))
          .Add(it => it.Param2dArray<int>("""[[2], [1, 1], [2, 2], [2, 2], [1], [3, 3], [2], [4, 4], [1], [3], [4]]""", true)
                       .ParamArray<string>("""["LRUCache", "put", "put", "put", "get", "put", "get", "put", "get", "get", "get"]""")
                       .ResultArray<object?>(null, null, null, null, 1, null, -1, null, -1, 3, 4));

    private IList<object?> Solution(int[][] data, string[] instructions)
    {
        var result = new List<object?>();

        CustomLRUCache? custom = null;
        for (int i = 0; i < instructions.Length; i++)
        {
            switch (instructions[i])
            {
                case "LRUCache":
                    custom = new CustomLRUCache(data[i][0]);
                    result.Add(null);
                    break;
                case "put":
                    result.Add(null);
                    custom!.Put(data[i][0], data[i][1]);
                    break;
                case "get":
                    result.Add(custom!.Get(data[i][0]));
                    break;
            }
        }

        return result;
    }

    private class CustomLRUCache
    {
        private readonly int _capacity;
        private readonly LinkedList<(int key, int value)> _lru = new();
        private readonly Dictionary<int, LinkedListNode<(int key, int value)>> _cache = new();

        public CustomLRUCache(int capacity)
        {
            _capacity = capacity;
        }

        public int Get(int key)
        {
            if (_cache.TryGetValue(key, out var node))
            {
                _lru.Remove(node);
                _lru.AddLast(node);
                return node.Value.value;
            }

            return -1;
        }

        public void Put(int key, int value)
        {
            if (_cache.TryGetValue(key, out var node))
            {
                node.Value = (key, value);
                _lru.Remove(node);
                _lru.AddLast(node);
            }
            else
            {
                _lru.AddLast((key, value));
                _cache.Add(key, _lru.Last!);
            }

            if (_cache.Count > _capacity)
            {
                _cache.Remove(_lru.First!.Value.key);
                _lru.RemoveFirst();
            }
        }
    }
}