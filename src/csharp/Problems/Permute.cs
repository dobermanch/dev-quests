//https://leetcode.com/problems/permutations/

namespace LeetCode.Problems;

public sealed class Permute : ProblemBase
{
    [Theory]
    [ClassData(typeof(Permute))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(true, it => it.ParamArray("[1,2,3]").Result2dArray("[[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,2,1],[3,1,2]]"))
          .Add(it => it.ParamArray("[1,2,3,4]").Result2dArray("[[1,2,3,4],[1,2,4,3],[1,3,2,4],[1,3,4,2],[1,4,3,2],[1,4,2,3],[2,1,3,4],[2,1,4,3],[2,3,1,4],[2,3,4,1],[2,4,3,1],[2,4,1,3],[3,2,1,4],[3,2,4,1],[3,1,2,4],[3,1,4,2],[3,4,1,2],[3,4,2,1],[4,2,3,1],[4,2,1,3],[4,3,2,1],[4,3,1,2],[4,1,3,2],[4,1,2,3]]"))
          .Add(it => it.ParamArray("[0,1]").Result2dArray("[[0,1],[1,0]]"))
          .Add(it => it.ParamArray("[1]").Result2dArray("[[1]]"));

    private IList<IList<int>> Solution(int[] nums)
    {
        void Permute(IList<int> temp, int index, IList<IList<int>> result)
        {
            if (index == temp.Count)
            {
                result.Add(temp.ToArray());
                return;
            }

            for (int i = index; i < temp.Count; i++)
            {
                (temp[i], temp[index]) = (temp[index], temp[i]);

                Permute(temp, index + 1, result);

                (temp[i], temp[index]) = (temp[index], temp[i]);
            }
        }

        var result = new List<IList<int>>();

        Permute(nums, 0, result);

        return result;
    }
}