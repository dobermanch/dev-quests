//https://leetcode.com/problems/removing-stars-from-a-string

namespace LeetCode.Problems;

public sealed class RemoveStars : ProblemBase
{
    [Theory]
    [ClassData(typeof(RemoveStars))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.Param("leet**cod*e").Result("lecoe"))
          .Add(it => it.Param("erase*****").Result(""));

    private string Solution(string s)
    {
        var stack = new char[s.Length];
        var index = 0;
        foreach(var ch in s)
        {
            if (ch is '*')
            {
                index--;
            }
            else 
            {
                stack[index++] = ch;
            }
        }

        return new string(stack, 0, index);
    }
}