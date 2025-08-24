// https://leetcode.com/problems/greatest-common-divisor-of-strings/

namespace LeetCode.Problems;

public sealed class GcdOfStrings : ProblemBase
{
    [Theory]
    [ClassData(typeof(GcdOfStrings))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param("ABCABC").Param("ABC").Result("ABC"))
          .Add(it => it.Param("ABABAB").Param("ABAB").Result("AB"))
          .Add(it => it.Param("TAUXXTAUXXTAUXXTAUXXTAUXX").Param("TAUXXTAUXXTAUXXTAUXXTAUXXTAUXXTAUXXTAUXXTAUXX").Result("TAUXX"))
          .Add(it => it.Param("ABCABD").Param("ABC").Result(""))
          .Add(it => it.Param("LEET").Param("CODE").Result(""));

    private string? Solution1(string str1, string str2)
    {
        var result = str2;
        while (result.Length > 0)
        {
            if (str1.Replace(result, "") == "" && str2.Replace(result, "") == "")
            {
                return result;
            }

            result = result[..^1];
        }

        return string.Empty;
    }

    private string? Solution2(string str1, string str2)
    {
        if (!(str1 + str2 == str2 + str1))
        {
            return string.Empty;
        }

        int Gcd(int left, int right)
        {
            if (right == 0)
            {
                return left;
            }

            return Gcd(right, left % right);
        }

        return str1[..Gcd(str1.Length, str2.Length)];
    }

    private string? Solution3(string str1, string str2)
    {
        if (str1 + str2 != str2 + str1)
        {
            return string.Empty;
        }

        var left = str1.Length;
        var right = str2.Length;

        while (right > 0)
        {
            (left, right) = (right, left % right);
        }

        return str2[..left];
    }
}