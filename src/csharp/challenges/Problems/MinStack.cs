//https://leetcode.com/problems/min-stack/

namespace LeetCode.Problems;

public sealed class MinStack : ProblemBase
{
    [Theory]
    [ClassData(typeof(MinStack))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param2dArray("[[],[2],[0],[3],[0],[],[],[],[],[],[],[]]", true)
                .ParamArray("MinStack", "push", "push", "push", "push", "getMin", "pop", "getMin", "pop", "getMin", "pop", "getMin")
                .ResultArray<object?>("[null, null, null, null, null, 0, null, 0, null, 0, null, 2]", true))
          .Add(it => it.Param2dArray("[[],[-2],[0],[-3],[],[],[],[]]", true)
              .ParamArray("MinStack", "push", "push", "push", "getMin", "pop", "top", "getMin")
              .ResultArray<object?>("[null, null, null, null, -3, null, 0, -2]", true));

    private IList<object?> Solution(int[][] data, string[] instructions)
    {
        var result = new List<object?>();

        var queue = new CustomStack();
        for (int i = 0; i < instructions.Length; i++)
        {
            switch (instructions[i])
            {
                case "MinStack":
                    result.Add(null);
                    break;
                case "push":
                    result.Add(null);
                    queue.Push(data[i][0]);
                    break;
                case "getMin":
                    result.Add(queue.GetMin());
                    break;
                case "pop":
                    queue.Pop();
                    result.Add(null);
                    break;
                case "top":
                    result.Add(queue.Top());
                    break;
            }
        }

        return result;
    }

    private class CustomStack
    {
        private readonly LinkedList<(int val, int min)> _values = new();

        public void Push(int val)
        {
            _values.AddLast(_values.Last == null ? (val, val) : (val, Math.Min(_values.Last.Value.min, val)));
        }

        public void Pop()
        {
            if (_values.Count > 0)
            {
                _values.RemoveLast();
            }
        }

        public int Top()
        {
            return _values.Last?.Value.val ?? 0;
        }

        public int GetMin()
        {
            return _values.Last?.Value.min ?? 0;
        }
    }

    private class CustomStack1
    {
        private readonly IList<int> _values = new List<int>();
        private readonly SortedList<int, int> _ordered = new();

        public void Push(int val)
        {
            _values.Add(val);

            if (!_ordered.ContainsKey(val))
            {
                _ordered.Add(val, 0);
            }

            _ordered[val]++;
        }

        public void Pop()
        {
            if (_values.Count > 0)
            {
                var value = _values[^1];
                _ordered[value]--;
                if (_ordered[value] == 0)
                {
                    _ordered.Remove(value);
                }

                _values.RemoveAt(_values.Count - 1);
            }
        }

        public int Top()
        {
            return _values[^1];
        }

        public int GetMin()
        {
            return _ordered.Count == 0 ? 0 : _ordered.First().Key;
        }
    }
}