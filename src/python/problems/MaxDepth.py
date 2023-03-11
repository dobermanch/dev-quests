# https://leetcode.com/problems/maximum-depth-of-binary-tree/
class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right

class MaxDepth:
    def Solution(self, root: Optional[TreeNode]) -> int:
        def Dfs(node, depth) -> int:
            if not node:
                return depth
            
            left = Dfs(node.left, depth)
            right = Dfs(node.right, depth)

            return 1 + max(left, right)

        return Dfs(root, 0)


MaxDepth().Solution(TreeNode(1, TreeNode(2), TreeNode(3)))
