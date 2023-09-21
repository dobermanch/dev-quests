#https://leetcode.com/problems/swap-nodes-in-pairs
from typing import Optional
from models.list_node import ListNode

class SwapPairs:
    def Solution(self, head: Optional[ListNode]) -> Optional[ListNode]:
        result = ListNode(next=head)
        prev = result
        current = prev.next

        while current and current.next:
            next = current.next.next
            prev.next = current.next
            prev.next.next = current
            current.next = next

            current = current.next
            prev = prev.next.next

        return result.next


SwapPairs().Solution(ListNode(1, ListNode(2, ListNode(3, ListNode(4)))))
