# https://leetcode.com/problems/count-good-nodes-in-binary-tree/
from core.ProblemBase import *

class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right

class GoodNodes:
    def Solution(self, root: TreeNode) -> int:
        stack = []
        stack.append((root, float('-inf')))
        count = 0
        while stack:
            node, parentMax = stack.pop()

            count += 1 if node.val >= parentMax else 0
            parentMax = max(parentMax, node.val)

            if node.left:
                stack.append((node.left, parentMax))
            
            if node.right:
                stack.append((node.right, parentMax))

        return count
    
    def Solution1(self, root: TreeNode) -> int:
        def Dfs(node, parentMax) -> int:
            if not node:
                return 0

            count = 1 if node.val >= parentMax else 0
            parentMax = max(parentMax, node.val)
            
            count += Dfs(node.left, parentMax)
            count += Dfs(node.right, parentMax)
            return count

        return Dfs(root, float('-inf'))


if __name__ == '__main__':
    TestGen(GoodNodes) \
        .Add(lambda tc: tc.Param("nums", [1,3,4,2,2]).Result(2)) \
        .Add(lambda tc: tc.Param("nums", [3,1,3,4,2]).Result(3)) \
        .Run()
