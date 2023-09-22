# https://leetcode.com/problems/remove-linked-list-elements/

from typing import Optional
from models.list_node import ListNode

class RemoveElements:
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


RemoveElements().Solution([ListNode(1, ListNode(2, ListNode(4))), ListNode(1, ListNode(3, ListNode(4))), ListNode(1, ListNode(2, ListNode(4))), ListNode(1, ListNode(3, ListNode(4)))])
