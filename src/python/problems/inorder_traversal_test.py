# https://leetcode.com/problems/binary-tree-inorder-traversal

from typing import Optional
from core.problem_base import *
from models.tree_node import *

class InorderTraversal(ProblemBase):
    def Solution1(self, root: Optional[TreeNode]) -> list[int]:
        result = []

        def Dfs(node):
            if not node:
                return
            
            Dfs(node.left)

            result.append(node.val)

            Dfs(node.right)

        Dfs(root)

        return result
    
    def Solution2(self, root: Optional[TreeNode]) -> list[int]:
        result = []
        stack = []

        node = root
        while node or stack:
            if node:
                stack.append(node)
                node = node.left
            else:
                pop = stack.pop()
                result.append(pop.val)
                node = pop.right

        return result

if __name__ == '__main__':
    TestGen(InorderTraversal) \
        .Add(lambda tc: tc.ParamTreeNode([1,None,2,3]).Result([1,3,2])) \
        .Add(lambda tc: tc.ParamTreeNode([]).Result([])) \
        .Add(lambda tc: tc.ParamTreeNode([1]).Result([1])) \
        .Run()
