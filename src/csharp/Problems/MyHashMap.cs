//https://leetcode.com/problems/design-hashmap

namespace LeetCode.Problems;

public sealed class MyHashMap : ProblemBase
{
    [Theory]
    [ClassData(typeof(MyHashMap))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param2dArray<int>("""[[], [1, 1], [2, 2], [1], [3], [2, 1], [2], [2], [2]]""", true)
                       .ParamArray<string>("""["MyHashMap", "put", "put", "get", "get", "put", "get", "remove", "get"]""")
                       .ResultArray<object?>(null, null, null, 1, -1, null, 1, null, -1));

    private IList<object?> Solution(int[][] data, string[] instructions)
    {
        var result = new List<object?>();

        var map = new HashMap();
        for (int i = 0; i < instructions.Length; i++)
        {
            switch (instructions[i])
            {
                case "MyHashMap":
                    result.Add(null);
                    break;
                case "put":
                    result.Add(null);
                    map.Put(data[i][0], data[i][1]);
                    break;
                case "get":
                    result.Add(map.Get(data[i][0]));
                    break;
                case "remove":
                    result.Add(null);
                    map.Remove(data[i][0]);
                    break;
            }
        }

        return result;
    }

    public class HashMap
    {
        class Data
        {
            public int Key;
            public int Value;
        }

        private readonly LinkedList<Data>?[] _data = new LinkedList<Data>?[1000];

        public void Put(int key, int value)
        {
            var index = key % _data.Length;

            _data[index] ??= new LinkedList<Data>();

            var node = _data[index]!.First;
            while (node != null)
            {
                if (node.Value.Key == key)
                {
                    node.Value.Value = value;
                    return;
                }

                node = node.Next;
            }

            _data[index]!.AddFirst(new Data {Key = key, Value = value});
        }

        public int Get(int key)
        {
            var node = GetNode(key);
            return node != null ? node.Value.Value : -1;
        }

        public void Remove(int key)
        {
            var node = GetNode(key);
            if (node != null)
            {
                _data[key % _data.Length]!.Remove(node);
            }
        }

        private LinkedListNode<Data>? GetNode(int key)
        {
            var node = _data[key % _data.Length]?.First;
            while (node != null)
            {
                if (node.Value.Key == key)
                {
                    return node;
                }

                node = node.Next;
            }

            return null;
        }
    }
}