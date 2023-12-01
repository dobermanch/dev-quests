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
    TestGen(PathSum2) \
        .Add(lambda tc: tc.ParamTreeNode([5,4,8,11,None,13,4,7,2,None,None,5,1]).Param(22).Result([[5,4,11,2],[5,8,4,5]])) \
        .Add(lambda tc: tc.ParamTreeNode([1,2,3]).Param(5).Result([])) \
        .Run()
