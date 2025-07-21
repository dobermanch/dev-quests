//https://leetcode.com/problems/construct-binary-tree-from-inorder-and-postorder-traversal/

namespace LeetCode.Problems;

public sealed class BuildTree2 : ProblemBase
{
    [Theory]
    [ClassData(typeof(BuildTree2))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamArray("[9,3,15,20,7]").ParamArray("[9,15,7,20,3]").ResultTree("[3,9,20,null,null,15,7]"))
          .Add(it => it.ParamArray("[-1]").ParamArray("[-1]").ResultTree("[-1]"));

    private TreeNode? Solution(int[] inorder, int[] postorder)
    {
        TreeNode? Build(Span<int> inorder, Span<int> postorder)
        {
            if (postorder.IsEmpty || inorder.IsEmpty)
            {
                return null;
            }

            var pos = inorder.IndexOf(postorder[^1]);
            return new TreeNode(postorder[^1])
            {
                left = Build(inorder[..pos], postorder[..pos]),
                right = Build(inorder[(pos + 1)..], postorder[pos..^1])
            };
        }

        return Build(inorder, postorder);
    }
}