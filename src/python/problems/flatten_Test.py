# https://leetcode.com/problems/flatten-binary-tree-to-linked-list

from typing import Optional
from core.problem_base import *
from models.tree_node import TreeNode

class CopyRandomList(ProblemBase):
    def Solution(self, root: Optional[TreeNode]) -> TreeNode:
        node = root
        while node:
            if node.left:
                current = node.left
                while current.right:
                    current = current.right
                
                current.right = node.right
                node.right = node.left
                node.left = None
            
            node = node.right

        return root


    def Solution1(self, root: Optional[TreeNode]) -> TreeNode:
        stack = []
        node = root
        prev: TreeNode = None
        while node or len(stack) > 0:
            if node:
                stack.append(node)
                prev = node
                node = node.left
            else:
                pop = stack.pop()
                node = pop.right

                if prev:
                    prev.right = node
                    if pop.left:
                        pop.right = pop.left
                        pop.left = None

        return root

if __name__ == '__main__':
    root = TreeNode(1, TreeNode(2, TreeNode(3), TreeNode(4)), TreeNode(5, None, TreeNode(6)))

    TestGen(CopyRandomList) \
        .Add(lambda tc: tc.Param(root).Result(root)) \
        .Run()
