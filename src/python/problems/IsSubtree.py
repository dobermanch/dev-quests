# https://leetcode.com/problems/subtree-of-another-tree/
class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right

class IsSubtree:
    def Solution(self, root: Optional[TreeNode], subRoot: Optional[TreeNode]) -> bool:
        def Dfs(node1, node2, checking) -> int:
            if not node1 and not node2:
                return True
            
            if not node1 or not node2:
                return False
            
            result = node1.val == node2.val
            if result:
                result = (Dfs(node1.left, node2.left, True) and
                          Dfs(node1.right, node2.right, True))
            
            if not result and not checking:
                result = (Dfs(node1.left, node2, False) or
                          Dfs(node1.right, node2, False))

            return result

        return Dfs(root, subRoot, False)


IsSubtree().Solution(TreeNode(1, TreeNode(2), TreeNode(3)), TreeNode(1, TreeNode(2), TreeNode(3)))
