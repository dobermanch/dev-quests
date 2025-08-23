//https://leetcode.com/problems/partition-labels/

namespace LeetCode.Problems;

public sealed class PartitionLabels : ProblemBase
{
    [Theory]
    [ClassData(typeof(PartitionLabels))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param("ababcbacadefegdehijhklij").ResultArray("[9,7,8]"))
          .Add(it => it.Param("abcde").ResultArray("[1,1,1,1,1]"))
          .Add(it => it.Param("abade").ResultArray("[3,1,1]"))
          .Add(it => it.Param("eccbbbbdec").ResultArray("[10]"));

    private IList<int> Solution(string s)
    {
        var result = new List<int>();
        var map = new int[26];

        for (var i = 0; i < s.Length; i++)
        {
            map[s[i] - 'a'] = i;
        }

        var right = 0;
        int length = 0;
        for (int left = 0; left < s.Length; left++)
        {
            length++;
            if (map[s[left] - 'a'] > right)
            {
                right = map[s[left] - 'a'];
            }

            if (left == right)
            {
                result.Add(length);
                length = 0;
            }
        }

        return result;
    }
}