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
    # TestGen(CloneGraph) \
    #     .Add(lambda tc: tc.Param([73,74,75,71,69,72,76,73]).Result([1,1,4,2,1,1,0,0])) \
    #     .Run()

    GetIntersectionNode().Solution(ListNode(1, ListNode(2, ListNode(3))), ListNode(1, ListNode(2, ListNode(3))))
