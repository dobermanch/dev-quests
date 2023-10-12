//https://leetcode.com/problems/smallest-number-in-infinite-set

namespace LeetCode.Problems;

public sealed class SmallestInfiniteSet : ProblemBase
{
    [Theory]
    [ClassData(typeof(SmallestInfiniteSet))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.Param2dArray("[[],[2],[],[],[],[5],[],[],[5],[]]", true)
                       .ParamArray<string>("""["SmallestInfiniteSet","addBack","popSmallest","popSmallest","popSmallest","addBack","popSmallest","popSmallest","addBack","popSmallest"]""")
                       .ResultArray<object>("[null,null,1,2,3,null,4,5,null,5]", true))
          .Add(it => it.Param2dArray("[[], [2], [], [], [], [1], [], [], []]", true)
                       .ParamArray<string>("""["SmallestInfiniteSet", "addBack", "popSmallest", "popSmallest", "popSmallest", "addBack", "popSmallest", "popSmallest", "popSmallest"]""")
                       .ResultArray<object>("[null, null, 1, 2, 3, null, 1, 4, 5]", true));

    private IList<object?> Solution(int[][] data, string[] instructions)
    {
        var result = new List<object>();

        var obj = new CustomSmallestInfiniteSet();
        for (int i = 0; i < instructions.Length; i++)
        {
            switch (instructions[i])
            {
                case "SmallestInfiniteSet":
                    result.Add(null);
                    break;
                case "popSmallest":
                    result.Add(obj.PopSmallest());
                    break;
                case "addBack":                    
                    result.Add(null);
                    obj.AddBack(data[i][0]);
                    break;
            }
        }

        return result;
    }

    public class CustomSmallestInfiniteSet
    {
        private readonly PriorityQueue<int, int> _queue = new ();
        private int _current = 1;
        
        public int PopSmallest()
        {
            if (_queue.Count <= 0 || _queue.Peek() > _current)
            {
                return _current++;
            }

            var num = _queue.Dequeue();
            _current += num == _current ? 1 : 0;

            while (_queue.Count > 0 && num == _queue.Peek())
            {
                _queue.Dequeue();
            }

            return num;
        }

        public void AddBack(int num) 
        {
            _queue.Enqueue(num, num);
        }
    }
}