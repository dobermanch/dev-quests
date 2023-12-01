# https://leetcode.com/problems/linked-list-cycle/

from typing import Optional
from models.list_node import ListNode
from core.problem_base import *

class HasCycle(ProblemBase):
    def Solution(self, head: Optional[ListNode]) -> bool:
        slow = head
        fast = head.next if head else None

        while slow and fast:
            if slow == fast:
                return True

            slow = slow.next
            fast = fast.next.next if fast.next else None

        return False


if __name__ == '__main__':
    # TestGen(HasCycle) \
    #     .Add(lambda tc: tc.Param([73,74,75,71,69,72,76,73]).Result([1,1,4,2,1,1,0,0])) \
    #     .Run()
    HasCycle().Solution(ListNode(1, ListNode(2, ListNode(3, ListNode(4)))))
