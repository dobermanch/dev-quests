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
    TestGen(ReverseKGroup) \
        .Add(lambda tc: tc.ParamListNode([1,2,3,4,5]).Param(2).ResultListNode([2,1,4,3,5])) \
        .Add(lambda tc: tc.ParamListNode([1,2,3,4,5]).Param(3).ResultListNode([3,2,1,4,5])) \
        .Run()
