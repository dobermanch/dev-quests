//https://leetcode.com/problems/first-unique-character-in-a-string/

namespace LeetCode.Problems;

public sealed class FirstUniqChar : ProblemBase
{
    [Theory]
    [ClassData(typeof(FirstUniqChar))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.Param("leetcode").Result(0))
          .Add(it => it.Param("loveleetcode").Result(2))
          .Add(it => it.Param("leetcffjfjrmmsparvnwllffzode").Result(3))
          .Add(it => it.Param("aabb").Result(-1));

    private int Solution(string s)
    {
        var map = Enumerable.Repeat(-1, 26).ToArray();

        for (var i = 0; i < s.Length; i++)
        {
            map[s[i] - 'a'] = map[s[i] - 'a'] == -1 ? i : int.MaxValue;
        }

        var min = map.Where(it => it is > -1 and < int.MaxValue).ToArray();

        return min.Any() ? min.Min() : -1;
    }
}