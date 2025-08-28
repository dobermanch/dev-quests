//https://leetcode.com/problems/delete-node-in-a-bst/

namespace LeetCode.Problems;

public sealed class DeleteNode : ProblemBase
{
    [Theory]
    [ClassData(typeof(DeleteNode))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamTree("[5,3,6,2,4,null,7]").Param(3).ResultTree("[5,4,6,2,null,null,7]"))
          .Add(it => it.ParamTree("[5,3,6,2,4,null,7]").Param(5).ResultTree("[6,3,7,2,4]"))
          .Add(it => it.ParamTree("[10,5,11,2,7,null,12,1,null,null,8]").Param(5).ResultTree("[10,7,11,2,8,null,12,1]"))
          .Add(it => it.ParamTree("[5,3,6,2,4,null,7]").Param(0).ResultTree("[5,3,6,2,4,null,7]"))
          .Add(it => it.ParamTree("[0]").Param(0).ResultTree("[]"))
          .Add(it => it.ParamTree("[]").Param(0).ResultTree("[]"))
          .Add(it => it.ParamTree("[2,0,33,null,1,25,40,null,null,11,31,34,45,10,18,29,32,null,36,43,46,4,null,12,24,26,30,null,null,35,39,42,44,null,48,3,9,null,14,22,null,null,27,null,null,null,null,38,null,41,null,null,null,47,49,null,null,5,null,13,15,21,23,null,28,37,null,null,null,null,null,null,null,null,8,null,null,null,17,19,null,null,null,null,null,null,null,7,null,16,null,null,20,6]").Param(33).ResultTree("[2,0,34,null,1,25,40,null,null,11,31,36,45,10,18,29,32,35,39,43,46,4,null,12,24,26,30,null,null,null,null,38,null,42,44,null,48,3,9,null,14,22,null,null,27,null,null,37,null,41,null,null,null,47,49,null,null,5,null,13,15,21,23,null,28,null,null,null,null,null,null,null,null,null,8,null,null,null,17,19,null,null,null,null,null,7,null,16,null,null,20,6]"))
          .Add(it => it.ParamTree("[10,4,12,2,7,11,13,1,null,6,9,null,null,null,null,null,null,null,null,8]").Param(4).ResultTree("[10,6,12,2,7,11,13,1,null,null,9,null,null,null,null,null,null,8]"))
          .Add(it => it.ParamTree("[10,4,11,2,7,null,12,1,null,6,8,null,null,null,null,5]").Param(4).ResultTree("[10,5,11,2,7,null,12,1,null,6,8]"))
          .Add(it => it.ParamTree("[7,3,8,2,5,null,9,1,null,4,6]").Param(3).ResultTree("[7,4,8,2,5,null,9,1,null,null,6]"))
          .Add(it => it.ParamTree("[7,4,8,2,5,null,9,1,null,null,6]").Param(3).ResultTree("[7,4,8,2,5,null,9,1,null,null,6]"));

    private TreeNode? Solution(TreeNode? root, int key)
    {
        TreeNode? Delete(TreeNode? node, int value)
        {
            if (node == null)
            {
                return null;
            }

            if (value < node.val)
            {
                node.left = Delete(node.left, value);
            }
            else if (value > node.val)
            {
                node.right = Delete(node.right, value);
            }
            else
            {
                if (node.right == null)
                {
                    return node.left;
                }

                if (node.left == null)
                {
                    return node.right;
                }

                var newRoot = node.right;
                while (newRoot.left != null)
                {
                    newRoot = newRoot.left;
                }

                newRoot.right = Delete(node.right, newRoot.val);
                newRoot.left = node.left;
                node = newRoot;
            }

            return node;
        }

        return Delete(root, key);
    }
}