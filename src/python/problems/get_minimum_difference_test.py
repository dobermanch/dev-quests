# https://leetcode.com/problems/minimum-absolute-difference-in-bst

from typing import Optional
from core.problem_base import *
from models.tree_node import TreeNode

class GetMinimumDifference(ProblemBase):
    def Solution(self, root: Optional[TreeNode]) -> int:
        stack = []
        diff = 10**5

        node = root
        prevNode = None
        while node or len(stack) > 0:
            if node:
                stack.append(node)
                node = node.left
            else:
                pop = stack.pop()

                if prevNode:
                    diff = min(diff, pop.val - prevNode.val)

                prevNode = pop
                node = pop.right

        return diff

if __name__ == '__main__':
    TestGen(GetMinimumDifference) \
        .Add(lambda tc: tc.ParamTreeNode([4,2,6,1,3]).Result(1)) \
        .Add(lambda tc: tc.ParamTreeNode([1,0,48,None,None,12,49]).Result(1)) \
        .Add(lambda tc: tc.ParamTreeNode([10,0,48,None,None,16,56]).Result(6)) \
        .Run()
