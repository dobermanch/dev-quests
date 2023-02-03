//https://leetcode.com/problems/task-scheduler/

namespace LeetCode.Problems;

public sealed class LeastInterval : ProblemBase
{
    [Theory]
    [ClassData(typeof(LeastInterval))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamArray('A','A','A','B','B','B').Param(2).Result(8))
          //.Add(it => it.ParamArray('A','A','A','B','B','B').Param(0).Result(6))
          //.Add(it => it.ParamArray(Array.Empty<char>()).Param(3).Result(0))
          .Add(it => it.ParamArray('A','A','A','A','A','A','B','C','D','E','F','G').Param(2).Result(16))
          .Add(it => it.ParamArray('A','A','A','B','B','B','C','C','C','D','D','E').Param(2).Result(12))
          .Add(it => it.ParamArray('A','A','A','B','B','B','C','C','D','D','F','F').Param(2).Result(12))
          .Add(it => it.ParamArray('A','A','A','A','A','B','B','B','C','C','C','D','D').Param(2).Result(13))
          ;
    public class Comparer : IComparer<(int, int, int)>
    {
        public int Compare((int, int, int) x, (int, int, int) y)
        {
            return x.Item3 == y.Item3 
                ? x.Item1 > y.Item1 ? -1 : 1 
                : x.Item3 > y.Item3 ? 1 : -1;
        }
    }
    private int Solution(char[] tasks, int n)
    {
        if (n == 0 || tasks.Length == 0)
        {
            return tasks.Length;
        }

        var queue = new PriorityQueue<(int, int, int), (int, int, int)>(tasks.GroupBy(it => it).Select((it, index) => ((it.Count(), 0, index), (it.Count(), 0, index))), new Comparer());
        //var map = new int[26, 2];
        //for (int i = 0; i < tasks.Length; i++)
        //{
        //    map[tasks[i] - 'A', 0]++;
        //}
        
        var units = 0;

        while (queue.Count > 0)
        {
            var item = queue.Dequeue();
            
            if ((item.Item2 == 0 || item.Item2 + n < units) && item.Item1 > 0)
            {
                item.Item1--;
                units++;
                if (item.Item1 > 0)
                {
                    item.Item2 = units;
                    if (item.Item3 == 0)
                    {
                        item.Item3=1;
                    }
                    item.Item3 += n;
                    queue.Enqueue(item, item);
                }
            }
            else
            {
                units++;
                item.Item3 += 1;
                queue.Enqueue(item, item);
            }
            
        }

        //var tasksToDo = tasks.Length;
        //while(tasksToDo > 0)
        //{
        //    bool addOne = true;
        //    for (int i = 0; i < map.GetLength(0); i++)
        //    {
        //        if ((map[i, 1] == 0 || map[i, 1] + n <= units) && map[i, 0] > 0)
        //        {
        //            map[i, 0]--;
        //            map[i, 1] = ++units;
        //            addOne = false;
        //            tasksToDo--;
        //        }
        //    }

        //    if (addOne)
        //    {
        //        units++;
        //    }
        //}

        return units;
    }
}