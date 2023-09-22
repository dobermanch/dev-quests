
from typing import Optional
from models.list_node import ListNode

class ReverseList:
    def Solution(self, head: Optional[ListNode]) -> Optional[ListNode]:
        result = None
        current = head
        while current:
            next = current.next
            current.next = result
            result = current
            current = next

        return result


ReverseList().Solution(ListNode(1, ListNode(2, ListNode(3))))
