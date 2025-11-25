
# https://leetcode.com/problems/path-sum-iii

from typing import List, Optional
from core.problem_base import *
from models.tree_node import TreeNode

class PathSumIii(ProblemBase):
    def Solution(self, root: Optional[TreeNode], targetSum: int) -> int:
        map = {0:1}

        def dfs(node, current_sum) -> int:
            if not node:
                return 0

            current_sum += node.val
            target = current_sum - targetSum
            count = 0
            if target in map:
                count = map[target]

            if current_sum not in map:
                map[current_sum] = 0

            map[current_sum] += 1

            count += dfs(node.left, current_sum)
            count += dfs(node.right, current_sum)

            map[current_sum] -= 1

            return count

        return dfs(root, 0)

if __name__ == '__main__':
    TestGen(PathSumIii) \
        .Add(lambda tc: tc.ParamTreeNode([10,5,-3,3,2,None,11,3,-2,None,1]).Param(8).Result(3)) \
        .Add(lambda tc: tc.ParamTreeNode([5,4,8,11,None,13,4,7,2,None,None,5,1]).Param(22).Result(3)) \
        .Run()
