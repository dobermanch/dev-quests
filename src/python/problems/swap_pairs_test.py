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
    # TestGen(SwapPairs) \
    #     .Add(lambda tc: tc.Param([73,74,75,71,69,72,76,73]).Result([1,1,4,2,1,1,0,0])) \
    #     .Run()
    SwapPairs().Solution(ListNode(1, ListNode(2, ListNode(3, ListNode(4)))))
