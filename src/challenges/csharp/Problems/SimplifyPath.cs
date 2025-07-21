//https://leetcode.com/problems/simplify-path

namespace LeetCode.Problems;

public sealed class SimplifyPath : ProblemBase
{
    [Theory]
    [ClassData(typeof(SimplifyPath))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param("/home/").Result("/home"))
          .Add(it => it.Param("/..hidden").Result("/..hidden"))
          .Add(it => it.Param("/a/./b/../../c/").Result("/c"))
          .Add(it => it.Param("/home/.././foo/").Result("/foo"))
          .Add(it => it.Param("/home/...").Result("/home/..."))
          .Add(it => it.Param("/../").Result("/"))
          .Add(it => it.Param("/home/user/Documents/../Pictures").Result("/home/user/Pictures"))
          .Add(it => it.Param("/home/user/../../usr/local/bin").Result("/usr/local/bin"))
          .Add(it => it.Param("/home/user/./Downloads/../Pictures/././").Result("/home/user/Pictures"))
          .Add(it => it.Param("/home/log.tst").Result("/home/log.tst"));

    private string Solution(string path)
    {
        var stack = new Stack<string>();

        var segment = new StringBuilder();
        for (int i = 0; i < path.Length; i++)
        {
            if (path[i] is not '/')
            {
                segment.Append(path[i]);
            }

            if (path[i] == '/' || i == path.Length - 1)
            {
                var dir = segment.ToString();
                if (dir == ".." && stack.Count > 0)
                {
                    stack.Pop();
                }
                else if (dir.Length > 0 && dir != "." && dir != "..")
                {
                    stack.Push(dir);
                }

                segment.Clear();
            }
        }

        var builder = new StringBuilder(stack.Count <= 0 ? "/" : "");
        while (stack.Count > 0)
        {
            var sub = stack.Pop();
            builder.Insert(0, $"/{sub}");
        }

        return builder.ToString();
    }
}