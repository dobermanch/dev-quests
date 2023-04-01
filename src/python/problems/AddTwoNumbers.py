# https://leetcode.com/problems/add-two-numbers/
class ListNode:
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next

class AddTwoNumbers:
    def Solution(self, l1: Optional[ListNode], l2: Optional[ListNode]) -> Optional[ListNode]:
        node1 = l1
        node2 = l2
        result = ListNode()
        current = result
        carry = 0

        while node1 or node2 or carry > 0:
            num1 = node1.val if node1 else 0
            num2 = node2.val if node2 else 0
            sum = carry + num1 + num2
            carry = sum // 10
            current.next = ListNode(sum % 10)
        
            current = current.next
            node1 = node1.next if node1 else None
            node2 = node2.next if node2 else None

        return result.next


AddTwoNumbers().Solution(ListNode(1, ListNode(2, ListNode(3))), ListNode(1, ListNode(2, ListNode(3))))
