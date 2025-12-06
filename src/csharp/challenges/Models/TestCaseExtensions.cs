namespace LeetCode.Models;

public static class TestCaseExtensions
{
    public static TestCase ParamArray<T>(this TestCase testCase, params T[]? data)
        => testCase.Param(data?.ToArray(), true);

    public static TestCase ParamArray(this TestCase testCase, string? input)
        => testCase.Param(input.ToArray<int>(), true);

    public static TestCase ParamArray<T>(this TestCase testCase, string? input)
        => testCase.Param(input.ToArray<T>(), true);

    public static TestCase ParamMatrix(this TestCase testCase, string? input)
        => testCase.Param(Matrix.Parse(input), true);

    public static TestCase Param2dArray(this TestCase testCase, string? data, bool includeEmpty = false)
        => testCase.Param(data.To2dArray<int>(includeEmpty), true);

    public static TestCase Param2dArray<T>(this TestCase testCase, string? data, bool includeEmpty = false)
        => testCase.Param(data.To2dArray<T>(includeEmpty), true);

    public static TestCase ParamList<T>(this TestCase testCase, string? input)
        => testCase.Param(input.ToArray<T>().ToList(), true);

    public static TestCase ParamList<T>(this TestCase testCase, params T[]? data)
        => testCase.Param(data?.ToList(), true);

    public static TestCase ParamTree(this TestCase testCase, string? input)
        => testCase.Param(TreeNode.Parse(input), true);

    public static TestCase ParamNode(this TestCase testCase, string? input, bool neighbors = false)
        => testCase.Param(Node.Parse(input, neighbors), true);

    public static TestCase ParamListNode(this TestCase testCase, string? input, int? cycleAtPos = null)
    {
        var lists = input.To2dArray<int>();
        return lists.Length <= 1
            ? testCase.Param(ListNode.Create(cycleAtPos, lists.FirstOrDefault()), true)
            : testCase.Param(lists.Select(it => ListNode.Create(cycleAtPos, it)).ToArray(), true);
    }



    public static TestCase ResultArray(this TestCase testCase, string? input)
        => testCase.Result(input.ToArray<int>(), true);

    public static TestCase ResultArray<T>(this TestCase testCase, params T[]? data)
        => testCase.Result(data?.ToArray<T>(), true);

    public static TestCase ResultArray<T>(this TestCase testCase, string? input)
        => testCase.Result(input.To2dArray<T>()[0], true);

    public static TestCase ResultArray<T>(this TestCase testCase, string? input, bool includeEmpty)
        => testCase.Result(input.To2dArray<T>(includeEmpty)[0], true);

    public static TestCase ResultMatrix(this TestCase testCase, string? input)
        => testCase.Result((int[][])Matrix.Parse(input), true);

    public static TestCase Result2dArray(this TestCase testCase, string? input)
        => testCase.Result((int[][])Matrix.Parse(input), true);

    public static TestCase Result2dArray(this TestCase testCase, string? input, bool includeEmpty)
        => testCase.Result(input.To2dArray<int>(includeEmpty), true);

    public static TestCase Result2dArray<T>(this TestCase testCase, string? input, bool includeEmpty = true)
        => testCase.Result(input.To2dArray<T>(includeEmpty), true);

    public static TestCase ResultTree(this TestCase testCase, string? input)
        => testCase.Result(TreeNode.Parse(input), true);

    public static TestCase ResultListNode(this TestCase testCase, string? input, int? cyclePosAt = null)
        => testCase.Result(ListNode.Parse(input, cyclePosAt), true);

    public static TestCase ResultNode(this TestCase testCase, string? input, bool neighbors = false)
        => testCase.Result(Node.Parse(input, neighbors), true);


    public static TestCase Data<T>(this TestCase testCase, string data)
        => testCase.Param2dArray<T>(data, true);

    public static TestCase Instructions(this TestCase testCase, string instrcutions)
        => testCase.ParamArray<string>(instrcutions);

    public static TestCase Output(this TestCase testCase, string output)
        => testCase.ResultArray<object?>(output, true);
}
