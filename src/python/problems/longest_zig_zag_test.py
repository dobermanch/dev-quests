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
    TestGen(LongestZigZag) \
        .Add(lambda tc: tc.ParamTreeNode([1,None,1,1,1,None,None,1,1,None,1,None,None,None,1]).Result(3)) \
        .Add(lambda tc: tc.ParamTreeNode([1,1,1,None,1,None,None,1,1,None,1]).Result(4)) \
        .Run()