# https://leetcode.com/problems/reverse-nodes-in-k-group/
class ListNode:
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next

class ReverseKGroup:
    def Solution(self, head: Optional[ListNode], k: int) -> Optional[ListNode]:
        def Reverse(node, length):
            group = None
            while node and length > 0:
                next = node.next

                node.next = group
                group = node
                node = next
                length -= 1

            return Reverse(group, k - length) if length > 0 else (group, node)

        result = ListNode()
        tail = head
        head = result
        while tail:
            lastElement = tail

            node = Reverse(tail, k)
            tail = node[1]

            head.next = node[0]
            head = lastElement

        return result.next



ReverseKGroup().Solution(ListNode(1, ListNode(2, ListNode(3, ListNode(4)))), 2)
