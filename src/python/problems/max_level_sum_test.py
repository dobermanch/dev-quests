# https://leetcode.com/problems/maximum-level-sum-of-a-binary-tree

from collections import deque
from typing import Optional
from core.problem_base import ProblemBase, TestGen
from models.tree_node import TreeNode

class MaxLevelSum(ProblemBase):
    def Solution(self, root: Optional[TreeNode]) -> int:
        queue = deque()
        queue.append((root, 1))

        levels = {}
        while queue:
            node, level = queue.popleft()
            levels[level] = levels.get(level, 0) + node.val

            if node.left:                
                queue.append((node.left, level + 1))

            if node.right:
                queue.append((node.right, level + 1))
        
        result = 1
        max = root.val
        for level, sum in levels.items():
            if sum > max:
                max = sum
                result = level

        return result

if __name__ == '__main__':
    node1 = TreeNode(1, TreeNode(7, TreeNode(7), TreeNode(-8)), TreeNode(0))

    TestGen(MaxLevelSum) \
        .Add(lambda tc: tc.Param(node1).Result(2)) \
        .Run()