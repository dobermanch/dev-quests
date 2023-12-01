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
    TestGen(HasCycle) \
        .Add(lambda tc: tc.ParamListNode([3,2,0,-4], 2).Result(True)) \
        .Add(lambda tc: tc.ParamListNode([1,2], 0).Result(True)) \
        .Add(lambda tc: tc.ParamListNode([1]).Result(False)) \
        .Run()
