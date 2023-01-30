//https://leetcode.com/problems/last-stone-weight

namespace LeetCode.Problems;

public sealed class LastStoneWeight : ProblemBase
{
    public static void Run()
    {
        //var d = Run(new [] {2,7,4,1,8,1}); // 1
        //var d = Run(new [] {1}); // 1
        var d = Run(new[] { 2, 2 }); // 0
    }

    private static int Run(int[] stones)
    {
        var comparer = Comparer<int>.Create((left, right) => right - left);
        var ordered = new PriorityQueue<int, int>(stones.Select(it => (it, it)), comparer);

        while (ordered.Count > 1)
        {
            var right = ordered.Dequeue();
            var left = ordered.Dequeue();

            if (right != left)
            {
                var value = right - left;
                ordered.Enqueue(value, value);
            }
        }

        return ordered.Count > 0 ? ordered.Dequeue() : 0;
    }
}