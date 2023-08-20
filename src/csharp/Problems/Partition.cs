//https://leetcode.com/problems/palindrome-partitioning/description/

namespace LeetCode.Problems;

public sealed class Partition : ProblemBase
{
    [Theory]
    [ClassData(typeof(Partition))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.Param("aab").Result2dArray<string>("""[["a","a","b"],["aa","b"]]"""))
          .Add(it => it.Param("a").Result2dArray<string>("""[["a"]]"""))
        ;
    
    private IList<IList<string>> Solution(string s)
    {
        var result = new List<IList<string>>();
        Find(s, 0, new List<string>(), result);
        return result;
    }

    private static void Find(ReadOnlySpan<char> data, int index, IList<string> temp, IList<IList<string>> result)
    {
        if (index == data.Length)
        {
            result.Add(temp.ToArray());
            return;
        }

        for (int i = index; i < data.Length; i++)
        {
            var pol = data[index..(i + 1)];
            if (IsPalindrome(pol))
            {
                temp.Add(pol.ToString());

                Find(data, i + 1, temp, result);

                temp.RemoveAt(temp.Count - 1);
            }
        }
    }

    private static bool IsPalindrome(ReadOnlySpan<char> str)
    {
        int i = -1;
        int length = str.Length / 2;
        while (++i < length && str[i] == str[^(i + 1)]) ;

        return i == length;
    }
}