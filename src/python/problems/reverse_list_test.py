
from typing import Optional
from models.list_node import ListNode
from core.problem_base import *

class ReverseList(ProblemBase):
    def Solution(self, head: Optional[ListNode]) -> Optional[ListNode]:
        result = None
        current = head
        while current:
            next = current.next
            current.next = result
            result = current
            current = next

        return result

if __name__ == '__main__':
    # TestGen(ReverseList) \
    #     .Add(lambda tc: tc.Param([73,74,75,71,69,72,76,73]).Result([1,1,4,2,1,1,0,0])) \
    #     .Run()
    ReverseList().Solution(ListNode(1, ListNode(2, ListNode(3))))
