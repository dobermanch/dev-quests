# https://leetcode.com/problems/path-sum-ii/
from typing import Optional
from models.tree_node import TreeNode
from core.problem_base import *

class PathSum2(ProblemBase):
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

if __name__ == '__main__':
    # TestGen(PathSum2) \
    #     .Add(lambda tc: tc.Param([73,74,75,71,69,72,76,73]).Result([1,1,4,2,1,1,0,0])) \
    #     .Run()
    PathSum2().Solution(TreeNode(1, TreeNode(2), TreeNode(3)), 3)
