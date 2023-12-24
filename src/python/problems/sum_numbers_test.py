# https://leetcode.com/problems/sum-root-to-leaf-numbers

from typing import Optional
from core.problem_base import *
from models.tree_node import TreeNode

class SumNumbers(ProblemBase):
    def Solution1(self, root: Optional[TreeNode]) -> int:
        stack = []
        sum = 0

        node = root
        while node or stack:
            prevNode = node
            if node:
                if not node.left and not node.right:
                    sum += node.val

                stack.append(node)
                node = node.left
            else:
                prevNode = stack.pop()
                node = prevNode.right

            if node and prevNode:
                node.val += prevNode.val * 10

        return sum
    
    def Solution2(self, root: Optional[TreeNode]) -> int:
        def GetSum(node, accum):
            if not node:
                return 0

            accum += node.val

            if not node.left and not node.right:
                return accum

            accum *= 10

            return GetSum(node.left, accum) + GetSum(node.right, accum)

        return GetSum(root, 0)

if __name__ == '__main__':
    TestGen(SumNumbers) \
        .Add(lambda tc: tc.ParamTreeNode([1,5,2,3,4,5,6,7,8,9]).Result(4875)) \
        .Add(lambda tc: tc.ParamTreeNode([4,9,0,5,1]).Result(1026)) \
        .Add(lambda tc: tc.ParamTreeNode([1,2,3]).Result(25)) \
        .Add(lambda tc: tc.ParamTreeNode([9]).Result(9)) \
        .Run()
