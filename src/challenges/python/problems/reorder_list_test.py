# https://leetcode.com/problems/reorder-list/
from typing import Optional
from models.list_node import ListNode
from core.problem_base import *

class ReorderList(ProblemBase):
    def Solution(self, head: Optional[ListNode]) -> None:
        """
        Do not return anything, modify head in-place instead.
        """
        
        slow = head
        fast = head.next

        while fast:
            slow = slow.next
            fast = fast.next.next if fast.next else None

        reverse = None
        while slow:
            next = slow.next
            slow.next = reverse
            reverse = slow
            slow = next

        lead = head
        tail = reverse
        while tail.next:
            leadNext = lead.next
            tailNext = tail.next

            lead.next = tail
            tail.next = leadNext

            lead = leadNext
            tail = tailNext

        return head


if __name__ == '__main__':
    TestGen(ReorderList) \
        .Add(lambda tc: tc.ParamListNode([1,2,3,4]).ResultListNode([1,4,2,3])) \
        .Add(lambda tc: tc.ParamListNode([1,2,3,4,5]).ResultListNode([1,5,2,4,3])) \
        .Run()
