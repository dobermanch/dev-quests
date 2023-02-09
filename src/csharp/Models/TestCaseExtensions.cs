namespace LeetCode.Models;

public static class TestCaseExtensions
{
    public static TestCase ParamMatrix(this TestCase testCase, Action<Matrix> build)
    {
        var matrix = new Matrix();
        build(matrix);
        return testCase.Param(matrix);
    }
    
    public static TestCase ParamMatrix(this TestCase testCase, string matrix) 
        => testCase.Param(Matrix.Parse(matrix));

    public static TestCase ParamArray(this TestCase testCase, string data)
    {
        var arr = Matrix.Parse(data);
        return testCase.Param(arr.Length == 0 ? Array.Empty<int>() : arr[0]);
    }

    public static TestCase Param2dArray(this TestCase testCase, string data) 
        => testCase.Param((int[][])Matrix.Parse(data));

    public static TestCase ParamArray<T>(this TestCase testCase, params T[]? data) 
        => testCase.Param(data?.ToArray());

    public static TestCase ParamList<T>(this TestCase testCase, params T[]? data) 
        => testCase.Param(data?.ToList());

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

    public static TestCase ResultArray<T>(this TestCase testCase, params T[]? data)
        => testCase.Result(data?.ToArray());

    public static TestCase ResultMatrix(this TestCase testCase, string matrix)
        => testCase.Result((int[][])Matrix.Parse(matrix));

    public static TestCase Result2dArray(this TestCase testCase, string matrix)
        => testCase.Result((int[][])Matrix.Parse(matrix));

    public static TestCase ResultArray(this TestCase testCase, string matrix)
    {
        var arr = Matrix.Parse(matrix);
        return testCase.Result(arr.Length == 0 ? Array.Empty<int>(): arr[0]);
    }
}