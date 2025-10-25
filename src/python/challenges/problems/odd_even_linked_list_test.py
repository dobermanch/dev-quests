
# https://leetcode.com/problems/odd-even-linked-list

from typing import List, Optional
from core.problem_base import *
from models.list_node import ListNode

class OddEvenLinkedList(ProblemBase):
    def Solution(self, head: Optional[ListNode]) -> Optional[ListNode]:
        if not head or not head.next:
            return head

        node = head.next.next
        odd_node = head
        even_head = head.next
        even_node = head.next

        while node:
            odd_node.next = node
            even_node.next = node.next

            odd_node = odd_node.next
            even_node = even_node.next
            node = node.next.next if node.next else None

        odd_node.next = even_head

        return head

if __name__ == '__main__':
    TestGen(OddEvenLinkedList) \
        .Add(lambda tc: tc.ParamListNode([1,2,3,4,5]).ResultListNode([1,3,5,2,4])) \
        .Add(lambda tc: tc.ParamListNode([2,1,3,5,6,4,7]).ResultListNode([2,3,6,7,1,5,4])) \
        .Run()
