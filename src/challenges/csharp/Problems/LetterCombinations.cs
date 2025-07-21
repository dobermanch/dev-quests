//https://leetcode.com/problems/letter-combinations-of-a-phone-number

using System.Reflection.Metadata.Ecma335;

namespace LeetCode.Problems;

public sealed class LetterCombinations : ProblemBase
{
    [Theory]
    [ClassData(typeof(LetterCombinations))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param("23").ResultArray<string>("""["ad","ae","af","bd","be","bf","cd","ce","cf"]"""))
          .Add(it => it.Param("233").ResultArray<string>("""["add","ade","adf","aed","aee","aef","afd","afe","aff","bdd","bde","bdf","bed","bee","bef","bfd","bfe","bff","cdd","cde","cdf","ced","cee","cef","cfd","cfe","cff"]"""))
          .Add(it => it.Param("2").ResultArray<string>("""["a","b","c"]"""))
          .Add(it => it.Param("").ResultArray<string>("[]"));

    private IList<string> Solution(string digits)
    {
        var map = new [] { 
            "abc", "def",
            "ghi", "jkl", "mno",
            "pqrs", "tuv", "wxyz"
        };

        void Search(char[] digits, int digitsIndex, char[] temp, int tempIndex, IList<string> result)
        {
            if (digitsIndex >= digits.Length)
            {
                result.Add(new string(temp));
                return;
            }
            
            foreach (var ch in map[digits[digitsIndex] - '2'])
            {
                temp[tempIndex] = ch;
                Search(digits, digitsIndex + 1, temp, tempIndex + 1, result);              
            }
        }

        var result = new List<string>();
        if (!string.IsNullOrEmpty(digits))
        {
            Search(digits.ToArray(), 0, new char[digits.Length], 0, result);
        }
        
        return result;
    }

    private IList<string> Solution1(string digits)
    {
        var map = new Dictionary<char, char[]>{
            {'2', new [] {'a','b','c'}},
            {'3', new [] {'d','e','f'}},
            {'4', new [] {'g','h','i'}},
            {'5', new [] {'j','k','l'}},            
            {'6', new [] {'m','n','o'}},
            {'7', new [] {'p','q','r','s'}},
            {'8', new [] {'t','u','v'}},
            {'9', new [] {'w','x','y','z'}}
        };

        void Search(char[] digits, int index, IList<char> temp, IList<string> result)
        {
            if (index >= digits.Length)
            {
                result.Add(new string(temp.ToArray()));
                return;
            }
            
            foreach (var ch in map[digits[index]])
            {
                temp.Add(ch);
                Search(digits, index + 1, temp, result);
                temp.RemoveAt(temp.Count - 1);                
            }
        }

        var result = new List<string>();
        if (!string.IsNullOrEmpty(digits))
        {
            Search(digits.ToArray(), 0, new List<char>(), result);
        }
        
        return result;
    }
}