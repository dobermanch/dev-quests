//https://leetcode.com/problems/bus-routes/

namespace LeetCode.Problems;

public sealed class NumBusesToDestination : ProblemBase
{
    [Theory]
    [ClassData(typeof(NumBusesToDestination))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.Param2dArray("[[1,2,7],[3,6,7],[6,5],[1,4]]").Param(1).Param(5).Result(3))
          .Add(it => it.Param2dArray("[[1,2,7],[3,6,7]]").Param(1).Param(6).Result(2))
          .Add(it => it.Param2dArray("[[1,2,7],[3,6,7]]").Param(1).Param(1).Result(0))
          .Add(it => it.Param2dArray("[[1,2,7],[3,6,7]]").Param(1).Param(2).Result(1))
          .Add(it => it.Param2dArray("[[0,1,6,16,22,23],[14,15,24,32],[4,10,12,20,24,28,33],[1,10,11,19,27,33],[11,23,25,28],[15,20,21,23,29],[29]]").Param(4).Param(21).Result(2))
          .Add(it => it.Param2dArray("[[7,12],[4,5,15],[6],[15,19],[9,12,13]]").Param(15).Param(12).Result(-1));

    private int Solution(int[][] routes, int source, int target)
    {
        if (source == target)
        {
            return 0;
        }

        var connected = new Dictionary<int, List<int>>();
        var queue = new Queue<(HashSet<int> route, int depth)>();
        for (var bus = 0; bus < routes.Length; bus++)
        {
            foreach (var stop in routes[bus])
            {
                if (!connected.ContainsKey(stop))
                {
                    connected[stop] = new();
                }

                connected[stop].Add(bus);

                if (stop == source)
                {
                    queue.Enqueue((routes[bus].ToHashSet(), 1));
                }
            }
        }

        if (!connected.ContainsKey(source) || !connected.ContainsKey(source))
        {
            return -1;
        }

        var visitedStops = new HashSet<int>();
        var visitedBuses = new HashSet<int>();
        while (queue.Any())
        {
            var (route, depth) = queue.Dequeue();
            if (route.Contains(target))
            {
                return depth;
            }

            foreach (var stop in route)
            {
                if (visitedStops.Contains(stop))
                {
                    continue;
                }

                visitedStops.Add(stop);
                foreach (var bus in connected[stop])
                {
                    if (!visitedBuses.Contains(bus))
                    {
                        visitedBuses.Add(bus);
                        queue.Enqueue((routes[bus].ToHashSet(), depth + 1));
                    }
                }
            }
        }

        return -1;
    }
}