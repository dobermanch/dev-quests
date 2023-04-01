//https://leetcode.com/problems/serialize-and-deserialize-binary-tree/

// ReSharper disable InconsistentNaming

namespace LeetCode.Problems;

public sealed class Codec : ProblemBase
{
    [Theory]
    [ClassData(typeof(Codec))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamTree("[1,2,3,null,null,4,5]").ResultTree("[1,2,3,null,null,4,5]"))
          .Add(it => it.ParamTree("[1,-2,3,null,null,4,5]").ResultTree("[1,-2,3,null,null,4,5]"))
          .Add(it => it.ParamTree("[]").ResultTree("[]"));

    private TreeNode? Solution(TreeNode? root)
    {
        var ser = new CodecInternal();
        var deser = new CodecInternal();
        return deser.deserialize(ser.serialize(root));
    }

    public class CodecInternal
    {
        public string? serialize(TreeNode? root)
        {
            if (root == null)
            {
                return null;
            }

            var builder = new StringBuilder();
            var queue = new Queue<TreeNode?>();
            queue.Enqueue(root);
            while (queue.Any())
            {
                var node = queue.Dequeue();

                if (node == null)
                {
                    builder.Append(",");
                    continue;
                }

                builder.Append($"{node.val},");

                queue.Enqueue(node.left);
                queue.Enqueue(node.right);
            }

            return builder.ToString().Trim(',');
        }

        public TreeNode? deserialize(string? data)
        {
            if (data == null)
            {
                return null;
            }

            var arr = data.Split(",")
                    .Select(x => int.TryParse(x, out var number) ? number : (int?)null)
                    .ToList();

            var root = new TreeNode(arr[0] ?? 0);
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            var index = 0;
            while (queue.Any() && index < arr.Count)
            {
                var node = queue.Dequeue();
                if (++index < arr.Count && arr[index] != null)
                {
                    node.left = new TreeNode(arr[index] ?? 0);
                    queue.Enqueue(node.left);
                }

                if (++index < arr.Count && arr[index] != null)
                {
                    node.right = new TreeNode(arr[index] ?? 0);
                    queue.Enqueue(node.right);
                }
            }

            return root;
        }
    }
}