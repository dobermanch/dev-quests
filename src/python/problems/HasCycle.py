# https://leetcode.com/problems/linked-list-cycle/
class ListNode:
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next

class HasCycle:
    def Solution(self, head: Optional[ListNode]) -> bool:
        slow = head
        fast = head.next if head else None

        while slow and fast:
            if slow == fast:
                return True

            slow = slow.next
            fast = fast.next.next if fast.next else None

        return False



HasCycle().Solution(ListNode(1, ListNode(2, ListNode(3, ListNode(4)))))
