//https://leetcode.com/problems/combinations/

using System.Drawing;
using System;

namespace LeetCode.Problems;

public sealed class Combine : ProblemBase
{
    [Theory]
    [ClassData(typeof(Combine))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param(4).Param(2).Result2dArray("[[1,2],[1,3],[1,4],[2,3],[2,4],[3,4]]"))
          .Add(it => it.Param(4).Param(3).Result2dArray("[[1,2,3],[1,2,4],[1,3,4],[2,3,4]]"))
          .Add(it => it.Param(1).Param(1).Result2dArray("[[1]]"));

    private IList<IList<int>> Solution(int n, int k)
    {
        var result = new List<IList<int>>();
        var temp = new List<int> {0};

        while (temp.Any())
        {
            var index = temp.Last();
            temp.RemoveAt(temp.Count - 1);
            while (++index <= n)
            {
                temp.Add(index);
                if (temp.Count == k)
                {
                    result.Add(temp.ToArray());
                    temp.RemoveAt(temp.Count - 1);
                }
            }
        }

        return result;
    }

    private IList<IList<int>> Solution1(int n, int k)
    {
        var result = new List<IList<int>>();
        var queue = new Queue<int>();
        var temp = new List<int> { 0 };

        while (temp.Any())
        {
            queue.Enqueue(temp.Last() + 1);
            temp.RemoveAt(temp.Count - 1);

            while (queue.Any())
            {
                var index = queue.Dequeue();

                if (index > n)
                {
                    continue;
                }

                temp.Add(index);
                if (temp.Count == k)
                {
                    result.Add(temp.ToArray());
                    temp.RemoveAt(temp.Count - 1);
                }

                if (index < n)
                {
                    queue.Enqueue(++index);
                }
            }
        }

        return result;
    }

    private IList<IList<int>> Solution2(int n, int k)
    {
        void Search(int range, int size, IList<int> temp, int index, IList<IList<int>> result)
        {
            while (true)
            {
                if (temp.Count == size)
                {
                    result.Add(temp.ToArray());
                    return;
                }

                if (index > range)
                {
                    return;
                }

                temp.Add(index);
                Search(range, size, temp, index + 1, result);
                temp.RemoveAt(temp.Count - 1);
                index += 1;
            }
        }

        var result = new List<IList<int>>();

        Search(n, k, new List<int>(), 1, result);

        return result;
    }
}