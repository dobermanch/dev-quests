# https://leetcode.com/problems/path-sum-ii/
class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right

class PathSum2:
    def Solution(self, root: Optional[TreeNode], targetSum: int) -> list[list[int]]:
        result = []
        def Dfs(node, currentSum, target, temp) -> int:
            if not node:
                return

            temp.append(node.val)
            currentSum += node.val
            if not node.left and not node.right:
                if currentSum == target:
                    result.append(list(temp))
                del temp[len(temp) - 1]
                return

            Dfs(node.left, currentSum, target, temp)
            Dfs(node.right, currentSum, target, temp)
            del temp[len(temp) - 1]

        Dfs(root, 0, targetSum, [])

        return result


PathSum2().Solution(TreeNode(1, TreeNode(2), TreeNode(3)), 3)
