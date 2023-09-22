#https://leetcode.com/problems/intersection-of-two-linked-lists

from typing import Optional
from models.list_node import ListNode

class GetIntersectionNode:
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


GetIntersectionNode().Solution(ListNode(1, ListNode(2, ListNode(3))), ListNode(1, ListNode(2, ListNode(3))))
