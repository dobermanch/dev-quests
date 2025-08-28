//https://leetcode.com/problems/letter-case-permutation/

namespace LeetCode.Problems;

public sealed class LetterCasePermutation : ProblemBase
{
    [Theory]
    [ClassData(typeof(LetterCasePermutation))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param("a1b2").ResultArray("a1b2","a1B2","A1B2","A1b2"))
          .Add(it => it.Param("3z4").ResultArray("3z4","3Z4"))
          .Add(it => it.Param("sd3E42D").ResultArray("sd3E42D","sd3E42d","sd3e42d","sd3e42D","sD3e42D","sD3e42d","sD3E42d","sD3E42D","SD3E42D","SD3E42d","SD3e42d","SD3e42D","Sd3e42D","Sd3e42d","Sd3E42d","Sd3E42D"));

    private IList<string> Solution(string s)
    {
        void Permute(char[] temp, int index, IList<string> result)
        {
            if (index == temp.Length)
            {
                result.Add(new string(temp));
                return;
            }

            Permute(temp, index + 1, result);

            if (char.IsLetter(temp[index]))
            {
                temp[index] = char.IsLower(temp[index]) ? char.ToUpper(temp[index]) : char.ToLower(temp[index]);
                Permute(temp, index + 1, result);
            }
        }

        var result = new List<string>();

        Permute(s.ToCharArray(), 0, result);

        return result;
    }
}