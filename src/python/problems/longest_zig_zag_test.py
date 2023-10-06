# https://leetcode.com/problems/longest-zigzag-path-in-a-binary-tree

from typing import Optional
from core.problem_base import ProblemBase, TestGen
from models.tree_node import TreeNode

class LongestZigZag(ProblemBase):
    def Solution(self, root: Optional[TreeNode]) -> int:
        def Dfs(node, depth, goLeft):
            if not node:
                return depth - 1
            
            current = Dfs(node.left if goLeft else node.right, depth + 1, not goLeft)
            alternative = Dfs(node.right if goLeft else node.left, 1, goLeft)

            return max(current, alternative)
        
        return Dfs(root, 0, True)

if __name__ == '__main__':
    node1 = TreeNode(1, None, TreeNode(1, TreeNode(1), TreeNode(1, TreeNode(1, None, TreeNode(1, None, TreeNode(1))), TreeNode(1))))

    TestGen(LongestZigZag) \
        .Add(lambda tc: tc.Param("root", node1).Result(3)) \
        .Run()