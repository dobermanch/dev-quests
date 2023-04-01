//https://leetcode.com/problems/find-median-from-data-stream/

namespace LeetCode.Problems;

public sealed class MedianFinder : ProblemBase
{
    [Theory]
    [ClassData(typeof(MedianFinder))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.Param2dArray("""[[],[1],[2],[],[3],[],[4],[]]""", true)
                .ParamArray<string>("""["MedianFinder","addNum","addNum","findMedian","addNum","findMedian","addNum","findMedian"]""")
                .ResultArray<object?>(null, null, null, 1.5, null, 2.0, null, 2.5))
          .Add(it => it.Param2dArray("""[[],[1],[2],[],[3],[]]""", true)
                .ParamArray<string>("""["MedianFinder","addNum","addNum","findMedian","addNum","findMedian"]""")
                .ResultArray<object?>(null, null, null, 1.5, null, 2.0))
          .Add(it => it.Param2dArray("""[[],[6],[],[10],[],[2],[],[6],[],[5],[],[0],[],[6],[],[3],[],[1],[],[0],[],[0],[]]""", true)
                .ParamArray<string>("""["MedianFinder","addNum","findMedian","addNum","findMedian","addNum","findMedian","addNum","findMedian","addNum","findMedian","addNum","findMedian","addNum","findMedian","addNum","findMedian","addNum","findMedian","addNum","findMedian","addNum","findMedian"]""")
                .ResultArray<object?>(null, null, 6.0, null, 8.0, null, 6.0, null, 6.0, null, 6.0, null, 5.5, null, 6.0, null, 5.5, null, 5.0, null, 4.0, null, 3.0))
          .Add(it => it.Param2dArray("""[[],[12],[],[10],[],[13],[],[11],[],[5],[],[15],[],[1],[],[11],[],[6],[],[17],[],[14],[],[8],[],[17],[],[6],[],[4],[],[16],[],[8],[],[10],[],[2],[],[12],[],[0],[]]""", true)
                .ParamArray<string>("""["MedianFinder","addNum","findMedian","addNum","findMedian","addNum","findMedian","addNum","findMedian","addNum","findMedian","addNum","findMedian","addNum","findMedian","addNum","findMedian","addNum","findMedian","addNum","findMedian","addNum","findMedian","addNum","findMedian","addNum","findMedian","addNum","findMedian","addNum","findMedian","addNum","findMedian","addNum","findMedian","addNum","findMedian","addNum","findMedian","addNum","findMedian","addNum","findMedian"]""")
                .ResultArray<object?>(null, null, 12.0, null, 11.0, null, 12.0, null, 11.5, null, 11.0, null, 11.5, null, 11.0, null, 11.0, null, 11.0, null, 11.0, null, 11.0, null, 11.0, null, 11.0, null, 11.0, null, 11.0, null, 11.0, null, 11.0, null, 10.5, null, 10.0, null, 10.5, null, 10.0));

    private IList<object?> Solution(int[][] data, string[] instructions)
    {
        var result = new List<object?>();

        var finder = new CustomMedianFinder();
        for (int i = 0; i < instructions.Length; i++)
        {
            switch (instructions[i])
            {
                case "MedianFinder":
                    result.Add(null);
                    break;
                case "addNum":
                    result.Add(null);
                    finder.AddNum(data[i][0]);
                    break;
                case "findMedian":
                    result.Add(finder.FindMedian());
                    break;
            }
        }

        return result;
    }

    public class CustomMedianFinder
    {
        private readonly PriorityQueue<int, int> _minQueue = new();
        private readonly PriorityQueue<int, int> _maxQueue = new();

        public void AddNum(int num)
        {
            _maxQueue.Enqueue(num, -num);
            if (_maxQueue.Count > _minQueue.Count + 1
                || _minQueue.Count > 0 && _maxQueue.Peek() > _minQueue.Peek())
            {
                var value = _maxQueue.Dequeue();
                _minQueue.Enqueue(value, value);
            }

            if (_minQueue.Count > _maxQueue.Count + 1)
            {
                var value = _minQueue.Dequeue();
                _maxQueue.Enqueue(value, -value);
            }
        }

        public double FindMedian()
        {
            if (_maxQueue.Count <= 0 && _minQueue.Count <= 0)
            {
                return 0;
            }

            if (_minQueue.Count == _maxQueue.Count)
            {
                return (_maxQueue.Peek() + _minQueue.Peek()) / 2f;
            }

            return _maxQueue.Count > _minQueue.Count ? _maxQueue.Peek() : _minQueue.Peek();
        }
    }
}