namespace LeetCode.Models;

public static class TestCaseExtensions
{
    public static TestCase ParamMatrix(this TestCase testCase, Action<Matrix> build)
    {
        var matrix = new Matrix();
        build(matrix);
        return testCase.Param(matrix);
    }

    public static TestCase ParamMatrix(this TestCase testCase, string? input) 
        => testCase.Param(Matrix.Parse(input));

    public static TestCase ParamArray(this TestCase testCase, string? input) 
        => testCase.Param(input.ToArray());

    public static TestCase Param2dArray(this TestCase testCase, string? data, bool includeEmpty = false) 
        => testCase.Param(data.To2dArray<int>(includeEmpty));

    public static TestCase Param2dArray<T>(this TestCase testCase, string? data, bool includeEmpty = false)
        => testCase.Param(data.To2dArray<T>(includeEmpty));

    public static TestCase ParamArray<T>(this TestCase testCase, params T[]? data) 
        => testCase.Param(data?.ToArray());

    public static TestCase ParamList<T>(this TestCase testCase, string? input)
        => testCase.Param(input.ToArray().ToList());

    public static TestCase ParamList<T>(this TestCase testCase, params T[]? data) 
        => testCase.Param(data?.ToList());

    public static TestCase ParamTree(this TestCase testCase, string? input)
        => testCase.Param(TreeNode.Parse(input));

    public static TestCase ParamTree(this TestCase testCase, params int?[] data) 
        => testCase.Param<TreeNode>(data);

    public static TestCase ParamListNode(this TestCase testCase, params int?[] data)
        => testCase.Param<ListNode>(data);

    public static TestCase ParamListNode(this TestCase testCase, string? input)
        => testCase.Param(ListNode.Parse(input));

    public static TestCase ParamNode(this TestCase testCase, params int?[] data)
        => testCase.Param<Node>(data);

    public static TestCase ParamNode(this TestCase testCase, string? input)
        => testCase.Param(Node.Parse(input));

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
        else if (typeof(T) == typeof(Node))
        {
            testCase.Param(Node.Create(false, data));
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

    public static TestCase ResultArray<T>(this TestCase testCase, params T[]? data)
        => testCase.Result(data?.ToArray());

    public static TestCase ResultMatrix(this TestCase testCase, string? input)
        => testCase.Result((int[][])Matrix.Parse(input));

    public static TestCase Result2dArray(this TestCase testCase, string? input)
        => testCase.Result((int[][])Matrix.Parse(input));

    public static TestCase ResultArray(this TestCase testCase, string? input) 
        => testCase.Result(input.ToArray());

    public static TestCase ResultTree(this TestCase testCase, string? input)
        => testCase.Result(TreeNode.Parse(input));

    public static TestCase ResultListNode(this TestCase testCase, string? input)
        => testCase.Result(ListNode.Parse(input));

    public static TestCase ResultNode(this TestCase testCase, string? input)
        => testCase.Result(Node.Parse(input));
}