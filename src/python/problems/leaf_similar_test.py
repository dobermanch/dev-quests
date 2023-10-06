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
    node1 = TreeNode(3, TreeNode(5, TreeNode(6), TreeNode(2, TreeNode(7), TreeNode(4))), TreeNode(1, TreeNode(9), TreeNode(8)))
    node2 = TreeNode(3, TreeNode(5, TreeNode(6), TreeNode(7)), TreeNode(1, TreeNode(4), TreeNode(2, TreeNode(9), TreeNode(8))))

    TestGen(LeafSimilar) \
        .Add(lambda tc: tc.Param("root1", node1).Param("root2", node2).Result(True)) \
        .Run()