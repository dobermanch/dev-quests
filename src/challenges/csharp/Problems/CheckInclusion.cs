//https://leetcode.com/problems/permutation-in-string/description/

namespace LeetCode.Problems;

public sealed class CheckInclusion : ProblemBase
{
    [Theory]
    [ClassData(typeof(CheckInclusion))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param("ab").Param("eidbaooo").Result(true))
          .Add(it => it.Param("ab").Param("eidboaoo").Result(false))
          .Add(it => it.Param("aba").Param("eidabaooo").Result(true))
          .Add(it => it.Param("aba").Param("eidbaaooo").Result(true))
          .Add(it => it.Param("ab").Param("ab").Result(true))
          .Add(it => it.Param("ab").Param("a").Result(false))
          .Add(it => it.Param("adc").Param("dcda").Result(true))
          .Add(it => it.Param("hello").Param("ooolleoooleh").Result(false))
          .Add(it => it.Param("abbc").Param("babadcbbabbcbabaabccbabc").Result(true));

    private bool Solution(string s1, string s2)
    {
        var map1 = s1.GroupBy(it => it).ToDictionary(it => it.Key, it => new[] {0, it.Count()});

        var left = 0;
        for (int right = 0; right < s2.Length; right++)
        {
            if (map1.ContainsKey(s2[right]))
            {
                map1[s2[right]][0]++;
            }

            if (right + 1 - left == s1.Length)
            {
                if (map1.All(it => it.Value[0] == it.Value[1]))
                {
                    return true;
                }

                if (map1.ContainsKey(s2[left]))
                {
                    map1[s2[left]][0]--;
                }

                left++;
            }
        }

        return false;
    }
}