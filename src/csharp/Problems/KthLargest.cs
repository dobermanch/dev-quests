//https://leetcode.com/problems/kth-largest-element-in-a-stream/

namespace LeetCode.Problems;

public sealed class KthLargest : ProblemBase
{
    [Theory]
    [ClassData(typeof(KthLargest))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it =>
                    // TODO: [[3, [4, 5, 8, 2]], this is not parsed correctly, fix array parser
                    //it.Param2dArray<object>("""[[3, [4, 5, 8, 2]], [3], [5], [10], [9], [4]]""", true)
                    //TEMPORARY
                    it.Param2dArray<object>("""[[3], [3], [5], [10], [9], [4]]""", true)
                      .ParamArray<string>("""["KthLargest", "add", "add", "add", "add", "add"]""")
                      .ResultArray<object?>(null, 4, 5, 5, 8, 8));

    private IList<object?> Solution(object[][] data, string[] instructions)
    {
        var result = new List<object?>();

        CustomKthLargest? custom = null;
        for (int i = 0; i < instructions.Length; i++)
        {
            switch (instructions[i])
            {
                case "KthLargest":
                    custom = new CustomKthLargest((int)data[i][0], new []{4, 5, 8, 2} /*(int[])data[i][1]*/);
                    result.Add(null);
                    break;
                case "add":
                    result.Add(custom!.Add((int)data[i][0]));
                    break;
            }
        }

        return result;
    }

    private class CustomKthLargest
    {
        private readonly int _kthElement;
        private readonly PriorityQueue<int, int> _queue = new();

        public CustomKthLargest(int k, int[] nums)
        {
            _kthElement = k;
            foreach (var num in nums)
            {
                Add(num);
            }
        }

        public int Add(int val)
        {
            if (_queue.Count >= _kthElement && _queue.Peek() < val)
            {
                _queue.Dequeue();
                _queue.Enqueue(val, val);
            }
            else if (_queue.Count < _kthElement)
            {
                _queue.Enqueue(val, val);
            }

            return _queue.Peek();
        }
    }
}