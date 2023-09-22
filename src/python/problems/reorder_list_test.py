# https://leetcode.com/problems/reorder-list/
from typing import Optional
from models.list_node import ListNode

class ReorderList:
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



ReorderList().Solution(ListNode(1, ListNode(2, ListNode(3, ListNode(4)))))
