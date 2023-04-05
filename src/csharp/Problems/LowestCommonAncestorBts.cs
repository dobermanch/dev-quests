//https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-search-tree/

namespace LeetCode.Problems;

public sealed class LowestCommonAncestorBts : ProblemBase
{
    [Theory]
    [ClassData(typeof(LowestCommonAncestorBts))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => AddSolutions(nameof(Solution1), nameof(Solution2))
          .Add(it => it.ParamTree("[6,2,8,0,4,7,9,null,null,3,5]").ParamTree("[2]").ParamTree("[8]").ResultTree("[6,2,8,0,4,7,9,null,null,3,5]"))
          .Add(it => it.ParamTree("[6,2,8,0,4,7,9,null,null,3,5]").ParamTree("[2]").ParamTree("[4]").ResultTree("[2,0,4,null,null,3,5]"));

    private TreeNode? Solution(TreeNode? root, TreeNode p, TreeNode q)
    {
        TreeNode? current = root;
        while (current != null)
        {
            if (current.val > p.val && current.val > q.val)
            {
                current = current.left;
            }
            else if (current.val < p.val && current.val < q.val)
            {
                current = current.right;
            }
            else
            {
                break;
            }
        }

        return current;
    }

    private TreeNode? Solution1(TreeNode? root, TreeNode p, TreeNode q)
    {
        if (root == null)
        {
            return null;
        }

        if (root.val > p.val && root.val > q.val)
        {
            return Solution1(root.left, p, q);
        }
        else if (root.val < p.val && root.val < q.val)
        {
            return Solution1(root.right, p, q);
        }

        return root;
    }

    private TreeNode Solution2(TreeNode root, TreeNode p, TreeNode q)
    {
        var pPath = new List<TreeNode> { root };
        var qPath = new List<TreeNode> { root };

        Search(root, p, pPath);
        Search(root, q, qPath);

        var min = Math.Min(pPath.Count, qPath.Count);
        for (var i = 0; i < min; i++)
        {
            if (pPath[i] != qPath[i])
            {
                return pPath[i - 1];
            }
        }

        return pPath[min - 1];
    }

    static void Search(TreeNode node, TreeNode target, IList<TreeNode> path)
    {
        path.Add(node);

        if (node.val != target.val)
        {
            Search(node.val > target.val ? node.left : node.right, target, path);
        }
    }
}