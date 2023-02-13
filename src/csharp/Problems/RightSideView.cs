//https://leetcode.com/problems/binary-tree-right-side-view/

namespace LeetCode.Problems;

public sealed class RightSideView : ProblemBase
{
    [Theory]
    [ClassData(typeof(RightSideView))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamTree("[1,2,3,null,5,null,4]").ResultArray("[1,3,4]"))
            .Add(it => it.ParamTree("[1,2,3,null,5,6,null,4]").ResultArray("[1,3,6,4]"))
            .Add(it => it.ParamTree("[1,null,3,2,5,null,null,4]").ResultArray("[1,3,5,4]"))
            .Add(it => it.ParamTree("[1,2,4,3,null,null,5,null,6,7,null,null,8,9,null,null,10,12,null]").ResultArray("[1,4,5,7,9,12]"))
            .Add(it => it.ParamTree("[1,2,3,null,4,5,null,null,6,7,null,null,8,9,null,null,10,9,null,null,10,9,null,null,10]").ResultArray("[1,3,5,7,9,9,9,10]"))
            .Add(it => it.ParamTree("[1,null,3]").ResultArray("[1,3]"))
            .Add(it => it.ParamTree((string)null).ResultArray("[]"));

    private IList<int> Solution1(TreeNode? root)
    {
        if (root == null)
        {
            return Array.Empty<int>();
        }

        var stack = new Queue<(TreeNode node, int level)>();
        stack.Enqueue((root, 1));
        var result = new List<int>();
        while (stack.Any())
        {
            var current = stack.Dequeue();

            if (result.Count < current.level)
            {
                result.Add(current.node.val);
            }

            if (current.node.right != null)
            {
                stack.Enqueue((current.node.right, current.level + 1));
            }

            if (current.node.left != null)
            {
                stack.Enqueue((current.node.left, current.level + 1));
            }
        }

        return result;
    }

    private IList<int> Solution2(TreeNode? root)
    {
        IList<int> CanSee(TreeNode? node)
        {
            if (node == null)
            {
                return Array.Empty<int>();
            }

            var result = new List<int> { node.val };
            var left = CanSee(node.left);
            var right = CanSee(node.right);

            result.AddRange(right);
            result.AddRange(left.Skip(right.Count));

            return result;
        }

        return CanSee(root);
    }
}