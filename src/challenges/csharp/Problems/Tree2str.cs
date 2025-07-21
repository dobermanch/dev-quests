//https://leetcode.com/problems/construct-string-from-binary-tree

namespace LeetCode.Problems;

public sealed class Tree2str : ProblemBase
{
    [Theory]
    [ClassData(typeof(Tree2str))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamTree("[1,2,3,4,5,6,7,8,null,9]").Result("1(2(4(8))(5(9)))(3(6)(7))"))
          .Add(it => it.ParamTree("[1,2,3,4,5,6,7,null,8,null,9]").Result("1(2(4()(8))(5()(9)))(3(6)(7))"))
          .Add(it => it.ParamTree("[1,2,3,4]").Result("1(2(4))(3)"))
          .Add(it => it.ParamTree("[1,2,3,null,4]").Result("1(2()(4))(3)"));

    private string Solution(TreeNode root)
    {
        var builder = new StringBuilder();

        void build(TreeNode node)
        {
            builder.Append(node.val);

            if (node.left is not null)
            {
                builder.Append("(");
                build(node.left);
                builder.Append(")");
            }

            if (node.right is not null)
            {
                if (node.left is null)
                {
                    builder.Append("()");
                }

                builder.Append("(");
                build(node.right);
                builder.Append(")");
            }
        }

        build(root);

        return builder.ToString();
    }
}