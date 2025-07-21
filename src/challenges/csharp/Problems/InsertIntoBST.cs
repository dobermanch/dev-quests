//https://leetcode.com/problems/insert-into-a-binary-search-tree/

namespace LeetCode.Problems;

public sealed class InsertIntoBST : ProblemBase
{
    [Theory]
    [ClassData(typeof(InsertIntoBST))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamTree("[4,2,7,1,3]").Param(5).ResultTree("[4,2,7,1,3,5]"))
          .Add(it => it.ParamTree("[40,20,60,10,30,50,70]").Param(25).ResultTree("[40,20,60,10,30,50,70,null,null,25]"))
          .Add(it => it.ParamTree("[40,20,60,10,24,50,70]").Param(25).ResultTree("[40,20,60,10,24,50,70,null,null,null,25]"))
          .Add(it => it.ParamTree("[4,2,7,1,3,null,null,null,null,null,null]").Param(5).ResultTree("[4,2,7,1,3,5]"))
          .Add(it => it.ParamTree("[]").Param(5).ResultTree("[5]"));

    private TreeNode? Solution(TreeNode? root, int val)
    {
        if (root == null)
        {
            return new TreeNode(val);
        }

        var node = root;
        while (node is not null)
        {
            if (val < node.val)
            {
                if (node.left is null)
                {
                    node.left = new TreeNode(val);
                    break;
                }

                node = node.left;
                continue;
            }

            if (node.right is null)
            {
                node.right = new TreeNode(val);
                break;
            }

            node = node.right;
        }

        return root;
    }
}