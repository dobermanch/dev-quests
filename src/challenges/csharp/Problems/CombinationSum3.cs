//https://leetcode.com/problems/combination-sum-iii

namespace LeetCode.Problems;

public sealed class CombinationSum3 : ProblemBase
{
    [Theory]
    [ClassData(typeof(CombinationSum3))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param(2).Param(6).Result2dArray("""[[1,5],[2,4]]"""))
          .Add(it => it.Param(3).Param(9).Result2dArray("""[[1,2,6],[1,3,5],[2,3,4]]"""))
          .Add(it => it.Param(3).Param(7).Result2dArray("""[[1,2,4]]"""))
          .Add(it => it.Param(4).Param(1).Result2dArray("""[]"""));

    private IList<IList<int>> Solution(int k, int n)
    {
        var result = new List<IList<int>>();
        var edge = Math.Min(9, n - k + 1);

        void Search(int current, IList<int> temp)
        {
            if (temp.Count == k)
            {
                if (temp.Sum() == n)
                {
                    result.Add(temp.ToArray());
                }

                return;
            }

            for (var i = current; i <= edge; i++)
            {
                temp.Add(i);
                Search(i + 1, temp);

                temp.RemoveAt(temp.Count - 1);
            }
        }

        Search(1, new List<int>());

        return result;
    }
}