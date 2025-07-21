# https://leetcode.com/problems/construct-string-from-binary-tree

from typing import Optional
from core.problem_base import *
from models.tree_node import TreeNode

class Tree2str(ProblemBase):
    def Solution(self, root: Optional[TreeNode]) -> str:
        result = ""

        def build(node):
            nonlocal result
            result += str(node.val)

            if node.left:
                result += "("
                build(node.left)
                result += ")"

            if node.right:
                if not node.left:
                    result += "()"

                result += "("
                build(node.right)
                result += ")"
        
        build(root)

        return result

if __name__ == '__main__':
    TestGen(Tree2str) \
        .Add(lambda tc: tc.ParamTreeNode([1,2,3,4]).Result("1(2(4))(3)")) \
        .Add(lambda tc: tc.ParamTreeNode([1,2,3,None,4]).Result("1(2()(4))(3)")) \
        .Run()
