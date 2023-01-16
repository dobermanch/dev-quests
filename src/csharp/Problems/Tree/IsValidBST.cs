public class IsValidBST {

    public static void Run() {
        //var node = new TreeNode(5, new TreeNode(1), new TreeNode(4, new TreeNode(3), new TreeNode(6)));
        //var node = new TreeNode(10, new TreeNode(5), new TreeNode(15, new TreeNode(6), new TreeNode(20)));
        //var node = new TreeNode(3, new TreeNode(1, new TreeNode(0), new TreeNode(2, null, new TreeNode(3))), new TreeNode(5, new TreeNode(4), new TreeNode(6)));
        var node = new TreeNode(-48, null, new TreeNode(94, new TreeNode(-3, null, new TreeNode(90)), null));
        //var node = new TreeNode(2, new TreeNode(1), new TreeNode(3));
        var d = Run(node);
    }

    private static bool Run(TreeNode root) 
    {
        var stack = new Stack<(int? left, int? right, TreeNode node)>();
        stack.Push((null, null, root));
        while(stack.Count > 0)
        {
            var current = stack.Pop();

            if (current.node.right != null) 
            {
                if (current.node.right.val <= current.node.val || (current.left != null && current.node.right.val >= current.left))
                {
                    return false;
                }

                stack.Push((current.left, Math.Min(current.node.val, current.left ?? current.node.val), current.node.right));
            }

            if (current.node.left != null)
            {
                if (current.node.left.val >= current.node.val || (current.right != null && current.node.left.val <= current.right))
                {
                    return false;
                }

                stack.Push((Math.Max(current.node.val, current.right ?? current.node.val), current.right, current.node.left));
            }
        }

        return true;
    }
}

