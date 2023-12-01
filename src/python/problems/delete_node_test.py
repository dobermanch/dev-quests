# https://leetcode.com/problems/delete-node-in-a-bst

from typing import Optional

from models.tree_node import TreeNode
from core.problem_base import *

class ZigzagLevelOrder(ProblemBase):
    def Solution(self, root: Optional[TreeNode], key: int) -> list[list[int]]:
        def Delete(node, value):
            if not node:
                return None

            if value < node.val:
                node.left= Delete(node.left, value)
            elif value > node.val:
                node.right = Delete(node.right, value)
            else:
                if not node.right:
                    return node.left
                if not node.left:
                    return node.right
                
                newRoot = node.right
                while newRoot.left:
                    newRoot = newRoot.left

                newRoot.right = Delete(node.right, newRoot.val)
                newRoot.left = node.left
                node = newRoot

            return node

        return Delete(root, key)

if __name__ == '__main__':
    # TestGen(ZigzagLevelOrder) \
    #     .Add(lambda tc: tc.Param([73,74,75,71,69,72,76,73]).Result([1,1,4,2,1,1,0,0])) \
    #     .Run()
    ZigzagLevelOrder().Solution(TreeNode(1, TreeNode(2), TreeNode(3)), 1)
