//https://leetcode.com/problems/group-anagrams/

namespace LeetCode.Problems;

public sealed class GroupAnagrams : ProblemBase
{
    [Theory]
    [ClassData(typeof(GroupAnagrams))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamArray<string>("""["eat", "tea", "tan", "ate", "nat", "bat"]""").Result2dArray<string>("""[["eat","tea","ate"],["tan","nat"],["bat"]]"""))
          //.Add(it => it.ParamArray<string>("").Result2dArray<string>("""[[""]]"""))
          .Add(it => it.ParamArray<string>("""["a"]""").Result2dArray<string>("""[["a"]]"""));

    private IList<IList<string>> Solution(string[] strs)
    {
        var map = new Dictionary<string, IList<string>>();
        foreach (var str in strs)
        {
            var hash = new char[26];
            foreach (var s in str)
            {
                hash[s - 'a']++;
            }

            var key = new string(hash);
            if (!map.ContainsKey(key))
            {
                map.Add(key, new List<string>());
            }

            map[key].Add(str);
        }

        return map.Values.ToArray();
    }
}