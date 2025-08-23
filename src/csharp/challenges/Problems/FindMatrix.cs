//https://leetcode.com/problems/convert-an-array-into-a-2d-array-with-conditions

namespace LeetCode.Problems;

public sealed class FindMatrix : ProblemBase
{
    [Theory]
    [ClassData(typeof(FindMatrix))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamArray("[1,3,4,1,2,3,1]").Result2dArray("[[1,3,4,2],[1,3],[1]]"))
          .Add(it => it.ParamArray("[1,2,3,4]").Result2dArray("[[1,2,3,4]]"));

    private IList<IList<int>> Solution(int[] nums)
    {
        var frequency = new int[nums.Length + 1];
        var result = new List<IList<int>>();

        foreach (var num in nums)
        {
            var index = frequency[num]++;
            if (result.Count <= index)
            {
                result.Add(new List<int>());
            }
            
            result[index].Add(num);
        }

        return result;
    }
}