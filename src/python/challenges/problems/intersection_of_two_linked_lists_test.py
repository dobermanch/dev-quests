#https://leetcode.com/problems/intersection-of-two-linked-lists

from typing import Optional
from models.list_node import ListNode
from core.problem_base import *

class GetIntersectionNode(ProblemBase):
    def Solution(self, headA: ListNode, headB: ListNode) -> Optional[ListNode]:
        def Modify(node):
            while node:
                node.val *= -1
                node = node.next

        Modify(headA)

        while headB:
            if headB.val < 0:
                break
            headB = headB.next

        Modify(headA)

        return headB

if __name__ == '__main__':
    node8 = ListNode(8, ListNode(4, ListNode(5)))
    node4 = ListNode(4, ListNode(1, node8))
    node5 = ListNode(5, ListNode(6, ListNode(1, node8)))
    TestGen(GetIntersectionNode) \
        .Add(lambda tc: tc.Param(node4).Param(node5).Result(node8)) \
        .Run()