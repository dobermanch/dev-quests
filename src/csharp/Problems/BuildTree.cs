//https://leetcode.com/problems/construct-binary-tree-from-preorder-and-inorder-traversal/

using System;

namespace LeetCode.Problems;

public sealed class BuildTree : ProblemBase
{
    [Theory]
    [ClassData(typeof(BuildTree))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamArray("[3,9,20,15,7]").ParamArray("[9,3,15,20,7]").ResultTree("[3,9,20,null,null,15,7]"))
          .Add(it => it.ParamArray("[3,9,8,6,1,2,20,15,7]").ParamArray("[8,9,1,6,2,3,15,20,7]").ResultTree("[3,9,20,8,6,15,7,null,null,1,2]"))
          .Add(it => it.ParamArray("[-1]").ParamArray("[-1]").ResultTree("[-1]"))
        ;

    private TreeNode Solution(int[] preorder, int[] inorder)
    {
        var set = inorder.Select((it, index) => (it, index)).ToDictionary(it => it.it, it => it.index);

        var stack = new Stack<(TreeNode node, int left, int right)>();
        stack.Push((new TreeNode(preorder[0]), 0, inorder.Length - 1));

        for (var i = 1; i < preorder.Length; i++)
        {
            var node = new TreeNode(preorder[i]);

            while (stack.Peek().node.val != node.val)
            {
                var parent = stack.Peek();
                if (set[preorder[i]] < set[parent.node.val] && set[preorder[i]] >= parent.left)
                {
                    parent.node.left = node;
                    stack.Push((node, parent.left, set[parent.node.val] - 1));
                }
                else if (set[preorder[i]] > set[parent.node.val] && set[preorder[i]] <= parent.right)
                {
                    parent.node.right = node;
                    stack.Push((node, set[parent.node.val] + 1, parent.right));
                }
                else
                {
                    stack.Pop();
                }
            }
        }

        return stack.Last().node;
    }
}