public class LowestCommonAncestor {

    public static void Run() {
        //var node = new TreeNode(5, new TreeNode(1), new TreeNode(4, new TreeNode(3), new TreeNode(6)));
        //var node = new TreeNode(10, new TreeNode(5), new TreeNode(15, new TreeNode(6), new TreeNode(20)));
        //var node = new TreeNode(3, new TreeNode(1, new TreeNode(0), new TreeNode(2, null, new TreeNode(3))), new TreeNode(5, new TreeNode(4), new TreeNode(6)));
        //var node = new TreeNode(-48, null, new TreeNode(94, new TreeNode(-3, null, new TreeNode(90)), null));
        //var node = new TreeNode(2, new TreeNode(1), new TreeNode(3));

        var node = TreeNode.Create(6,2,8,0,4,7,9,null,null,3,5);
        //var node = TreeNode.Create(2,1);
        var d = Run(node, new TreeNode(2), new TreeNode(4));
        //var d = Run(node, new TreeNode(2), new TreeNode(1));
    }

/// OPTION 3
    private static TreeNode Run(TreeNode root, TreeNode p, TreeNode q) 
    {
        TreeNode current = root;
        while(current != null)
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

/// OPTION 2
    // private static TreeNode Run(TreeNode root, TreeNode p, TreeNode q)
    // {
    //     if (root == null) 
    //     {
    //         return null;
    //     }

    //     if (root.val > p.val && root.val > q.val)
    //     {
    //         return Run(root.left, p, q);
    //     }
    //     else if (root.val < p.val && root.val < q.val)
    //     {
    //         return Run(root.right, p, q);
    //     }

    //     return root;
    // }

/// OPTION 1
    // private static TreeNode Run(TreeNode root, TreeNode p, TreeNode q)
    // {
    //     var pPath = new List<TreeNode> {root};
    //     var qPath = new List<TreeNode> {root};

    //     Search(root, p, pPath);
    //     Search(root, q, qPath);

    //     var min = Math.Min(pPath.Count, qPath.Count);
    //     for(var i = 0; i < min; i++) 
    //     {
    //         if (pPath[i] != qPath[i]) 
    //         {
    //             return pPath[i - 1];
    //         }
    //     }

    //     return pPath[min - 1];
    // }

    // static void Search(TreeNode node, TreeNode target, IList<TreeNode> path) {
    //     path.Add(node);

    //     if (node.val != target.val) {
    //         Search(node.val > target.val ? node.left : node.right, target, path);
    //     }
    // }
}

