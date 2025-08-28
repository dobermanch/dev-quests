//https://leetcode.com/problems/binary-search-tree-iterator/

namespace LeetCode.Problems;

public sealed class BSTIterator : ProblemBase
{
    [Theory]
    [ClassData(typeof(BSTIterator))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamTree("[7,3,15,null,null,9,20]").ParamArray("BSTIterator","next","next","hasNext","next","hasNext","next","hasNext","next","hasNext").ResultArray<object?>(null,3,7,true,9,true,15,true,20,false));

    private IList<object?> Solution(TreeNode root, string[] instructions)
    {
        var result = new List<object?>();

        var iterator = new Iterator(root);
        foreach (var instruction in instructions)
        {
            switch (instruction)
            {
                case "BSTIterator":
                    result.Add(null);
                    break;
                case "next":
                    result.Add(iterator.Next());
                    break;
                case "hasNext":
                    result.Add(iterator.HasNext());
                    break;
            }
        }

        return result;
    }

    public class Iterator
    {
        private readonly Queue<TreeNode> _queue = new();

        public Iterator(TreeNode root)
        {
            Build(root);
        }

        public int Next() => _queue.Dequeue().val;

        public bool HasNext() => _queue.Any();

        private void Build(TreeNode? node)
        {
            if (node == null)
            {
                return;
            }
            
            Build(node.left);
            _queue.Enqueue(node);
            Build(node.right);
        }
    }

    public class Iterator1
    {
        private readonly Stack<TreeNode> _stack = new();
        private TreeNode? _current;

        public Iterator1(TreeNode root)
        {
            Next(root);
        }

        public int Next()
        {
            if (_current == null)
            {
                throw new ArgumentOutOfRangeException();
            }

            var value = _current.val;

            Next(_current.right);

            return value;
        }

        public bool HasNext()
        {
            return _stack.Any() || _current != null || _current?.right != null;
        }

        private void Next(TreeNode? node)
        {
            var current = node;
            while (current != null)
            {
                _stack.Push(current);
                current = current.left;
            }

            _stack.TryPop(out _current);
        }
    }
}