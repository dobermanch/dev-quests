#https://leetcode.com/problems/remove-duplicates-from-sorted-list-ii/
class ListNode:
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next

class DeleteDuplicates:
    def Solution(self, head: Optional[ListNode]) -> Optional[ListNode]:
        prev = ListNode(next=head)
        head = prev
        current = head.next
        remove = False
        while current:
            if current.next and current.val == current.next.val:
                prev.next = current.next
                remove = True
            elif remove:
                prev.next = current.next
                remove = False
            else:
                prev = current

            current = current.next

        return head.next


DeleteDuplicates().Solution(ListNode(1, ListNode(2, ListNode(2))))
