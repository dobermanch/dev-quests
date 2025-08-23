//https://leetcode.com/problems/keys-and-rooms

namespace LeetCode.Problems;

public sealed class CanVisitAllRooms : ProblemBase
{
    [Theory]
    [ClassData(typeof(CanVisitAllRooms))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param2dArray("[[1],[2],[3],[]]", true).Result(true))
          .Add(it => it.Param2dArray("[[1,3],[1,4],[2,3,4,1],[],[4,3,2]]", true).Result(true))
          .Add(it => it.Param2dArray("[[4],[3],[],[2,5,7],[1],[],[8,9],[],[],[6]]", true).Result(false))
          .Add(it => it.Param2dArray("[[1,3],[3,0,1],[2],[0]]", true).Result(false));

    private bool Solution(IList<IList<int>> rooms)
    {
        var collectedKeys = new HashSet<int> {0};
        var stack = new Stack<int>();
        stack.Push(collectedKeys.First());
        while (stack.Any())
        {
            var roomKey = stack.Pop();
            foreach (var key in rooms[roomKey])
            {
                if (!collectedKeys.Contains(key))
                {
                    stack.Push(key);
                    collectedKeys.Add(key);
                }
            }
        }

        return collectedKeys.Count == rooms.Count;
    }
}