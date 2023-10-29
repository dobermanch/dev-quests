namespace LeetCode.Models;

public static class TestCaseExtensions
{
    public static TestCase ParamArray<T>(this TestCase testCase, params T[]? data)
        => testCase.Param(data?.ToArray());

    public static TestCase ParamArray(this TestCase testCase, string? input)
        => testCase.Param(input.ToArray<int>());

    public static TestCase ParamArray<T>(this TestCase testCase, string? input)
        => testCase.Param(input.ToArray<T>());

    public static TestCase ParamMatrix(this TestCase testCase, string? input)
        => testCase.Param(Matrix.Parse(input));

    public static TestCase Param2dArray(this TestCase testCase, string? data, bool includeEmpty = false) 
        => testCase.Param(data.To2dArray<int>(includeEmpty));

    public static TestCase Param2dArray<T>(this TestCase testCase, string? data, bool includeEmpty = false)
        => testCase.Param(data.To2dArray<T>(includeEmpty));

    public static TestCase ParamList<T>(this TestCase testCase, string? input)
        => testCase.Param(input.ToArray<T>().ToList());

    public static TestCase ParamList<T>(this TestCase testCase, params T[]? data) 
        => testCase.Param(data?.ToList());

    public static TestCase ParamTree(this TestCase testCase, string? input)
        => testCase.Param(TreeNode.Parse(input));

    public static TestCase ParamNode(this TestCase testCase, string? input, bool neighbors = false)
        => testCase.Param(Node.Parse(input, neighbors));

    public static TestCase ParamListNode(this TestCase testCase, string? input, int? cycleAtPos = null)
    {
        var lists = input.To2dArray<int>();
        return lists.Length <= 1 
            ? testCase.Param(ListNode.Create(cycleAtPos, lists.FirstOrDefault()))
            : testCase.Param(lists.Select(it => ListNode.Create(cycleAtPos, it)).ToArray());
    }



    public static TestCase ResultArray(this TestCase testCase, string? input)
        => testCase.Result(input.ToArray<int>());

    public static TestCase ResultArray<T>(this TestCase testCase, params T[]? data)
        => testCase.Result(data?.ToArray<T>());

    public static TestCase ResultArray<T>(this TestCase testCase, string? input)
        => testCase.Result(input.To2dArray<T>()[0]);

    public static TestCase ResultArray<T>(this TestCase testCase, string? input, bool includeEmpty)
        => testCase.Result(input.To2dArray<T>(includeEmpty)[0]);

    public static TestCase ResultMatrix(this TestCase testCase, string? input)
        => testCase.Result((int[][])Matrix.Parse(input));

    public static TestCase Result2dArray(this TestCase testCase, string? input)    
        => testCase.Result((int[][])Matrix.Parse(input));
    
    public static TestCase Result2dArray(this TestCase testCase, string? input, bool includeEmpty)
        => testCase.Result(input.To2dArray<int>(includeEmpty));

    public static TestCase Result2dArray<T>(this TestCase testCase, string? input)
        => testCase.Result(input.To2dArray<T>());

    public static TestCase ResultTree(this TestCase testCase, string? input)
        => testCase.Result(TreeNode.Parse(input));

    public static TestCase ResultListNode(this TestCase testCase, string? input, int? cyclePosAt = null)
        => testCase.Result(ListNode.Parse(input, cyclePosAt));

    public static TestCase ResultNode(this TestCase testCase, string? input, bool neighbors = false)
        => testCase.Result(Node.Parse(input, neighbors));
}