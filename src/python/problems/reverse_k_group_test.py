# https://leetcode.com/problems/reverse-nodes-in-k-group/

from typing import Optional
from models.list_node import ListNode
from core.problem_base import *

class ReverseKGroup(ProblemBase):
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


if __name__ == '__main__':
    # TestGen(ReverseKGroup) \
    #     .Add(lambda tc: tc.Param([73,74,75,71,69,72,76,73]).Result([1,1,4,2,1,1,0,0])) \
    #     .Run()
    ReverseKGroup().Solution(ListNode(1, ListNode(2, ListNode(3, ListNode(4)))), 2)
