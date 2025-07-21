//https://leetcode.com/problems/string-compression/

namespace LeetCode.Problems;

public sealed class Compress : ProblemBase
{
    [Theory]
    [ClassData(typeof(Compress))]
    public override void Test(object[] data) => base.Test(data);

    //TODO: ADD CUSTOM Result comparer
    protected override void AddTestCases()
        => Add(it => it.ParamArray<char>("['a','a','b','b','c','c','c']").Result(6)) //["a","2","b","2","c","3"]
          .Add(it => it.ParamArray<char>("['a']").Result(1)) // ["a"]
          .Add(it => it.ParamArray<char>("['a','b','b','b','b','b','b','b','b','b','b','b','b']").Result(4)); //["a","b","1","2"]

    private int Solution(char[] chars) 
    {
        int Compress(char[] data, int index, char current, int count) 
        {
            data[index++] = current;
            if (count > 1)
            {
                foreach(var ch in count.ToString())
                {
                    data[index++] = ch;
                }
            }
            return index;
        }

        var left = 0;
        var right = 1;
        var current = chars[0];
        var count = 1;
        while (right < chars.Length)
        {
            if (chars[right] == current)
            {
                count++;
                right++;
                continue;
            }

            left = Compress(chars, left, current, count);
            current = chars[right];
            count = 1;            
            right++;
        }

        return Compress(chars, left, current, count);
    }
}