# https://leetcode.com/problems/remove-linked-list-elements/

from typing import Optional
from models.list_node import ListNode
from core.problem_base import *

class RemoveElements(ProblemBase):
    def Solution(self, head: Optional[ListNode], val: int) -> Optional[ListNode]:
        prev = head
        current = head
        while current:
            if current.val != val:
                prev = current
            else:
                prev.next = current.next

            current = current.next

        return head if not head or head.val != val else head.next

#if __name__ == '__main__':
    # TestGen(RemoveElements) \
    #     .Add(lambda tc: tc.Param([73,74,75,71,69,72,76,73]).Result([1,1,4,2,1,1,0,0])) \
    #     .Run()
    #RemoveElements().Solution([ListNode(1, ListNode(2, ListNode(4))), ListNode(1, ListNode(3, ListNode(4))), ListNode(1, ListNode(2, ListNode(4))), ListNode(1, ListNode(3, ListNode(4)))])
