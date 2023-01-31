namespace LeetCode.Models;

public static class TestCaseExtensions
{
    public static TestCase Param<T>(this TestCase testCase, params int?[] data)
    {
        if (typeof(T) == typeof(ListNode))
        {
            testCase.Param(ListNode.Create(data == null ? null : data.Where(it => it != null).Select(it => it.Value).ToArray()));
        }
        else if (typeof(T) == typeof(TreeNode))
        {
            testCase.Param(TreeNode.Create(data));
        }
        else
        {
            throw new ArgumentException($"The '{typeof(T)}' type is not supported");
        }

        return testCase;
    }

    public static TestCase Result<T>(this TestCase testCase, params int?[] data)
    {
        if (typeof(T) == typeof(ListNode))
        {
            testCase.Result(ListNode.Create(data.Where(it => it != null).Select(it => it.Value).ToArray()));
        }
        else if (typeof(T) == typeof(TreeNode))
        {
            testCase.Result(TreeNode.Create(data));
        }
        else
        {
            throw new ArgumentException($"The '{typeof(T)}' type is not supported");
        }

        return testCase;
    }
}