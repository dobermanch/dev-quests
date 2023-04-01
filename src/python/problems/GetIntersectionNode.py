#https://leetcode.com/problems/intersection-of-two-linked-lists
class ListNode:
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next

class GetIntersectionNode:
    def Solution(self, headA: ListNode, headB: ListNode) -> Optional[ListNode]:
        def Modify(node):
            while node:
                node.val *= -1
                node = node.next

        Modify(headA)

        while headB:
            if headB.val < 0:
                break
            headB = headB.next

        Modify(headA)

        return headB


GetIntersectionNode().Solution(ListNode(1, ListNode(2, ListNode(3))), ListNode(1, ListNode(2, ListNode(3))))
