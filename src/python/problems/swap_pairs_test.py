#https://leetcode.com/problems/swap-nodes-in-pairs
from typing import Optional
from models.list_node import ListNode
from core.problem_base import *

class SwapPairs(ProblemBase):
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

if __name__ == '__main__':
    TestGen(SwapPairs) \
        .Add(lambda tc: tc.ParamListNode([1,2,3,4]).ResultListNode([2,1,4,3])) \
        .Add(lambda tc: tc.ParamListNode([]).ResultListNode([])) \
        .Add(lambda tc: tc.ParamListNode([1]).ResultListNode([1])) \
        .Run()
