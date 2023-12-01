# https://leetcode.com/problems/leaf-similar-trees/

from typing import Optional
from core.problem_base import ProblemBase, TestGen
from models.tree_node import TreeNode

class LeafSimilar(ProblemBase):
    def Solution(self, root1: Optional[TreeNode], root2: Optional[TreeNode]) -> bool:
        def Dfs(node, result) -> int:
            if node and not node.left and not node.right:
                result.append(node.val)
                return 
            
            if node.left:
                Dfs(node.left, result)
            
            if node.right:
                Dfs(node.right, result)

        result1 = []
        Dfs(root1, result1)

        result2 = []
        Dfs(root2, result2)

        return result1 == result2

if __name__ == '__main__':
    TestGen(LeafSimilar) \
        .Add(lambda tc: tc.ParamTreeNode([3,5,1,6,2,9,8,None,None,7,4]).ParamTreeNode([3,5,1,6,7,4,2,None,None,None,None,None,None,9,8]).Result(True)) \
        .Add(lambda tc: tc.ParamTreeNode([1,2,3]).ParamTreeNode([1,3,2]).Result(False)) \
        .Run()