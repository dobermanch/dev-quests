# https://leetcode.com/problems/maximum-twin-sum-of-a-linked-list

from typing import Optional
from core.problem_base import *
from models.list_node import *

class DeleteMiddle(ProblemBase):
    def Solution(self, head: Optional[ListNode]) -> int:
        if not head.next:
            return None

        slow = head
        fast = head

        while fast and fast.next:
            slow = slow.next
            fast = fast.next.next

        tail = None
        while slow:
            next = slow.next
            slow.next = tail
            tail = slow
            slow = next
        
        result = 0
        while tail:
            result = max(result, tail.val + head.val)
            head = head.next
            tail = tail.next
        
        return result


if __name__ == '__main__':
    TestGen(DeleteMiddle) \
        .Add(lambda tc: tc.ParamListNode([5,4,2,1]).Result(6)) \
        .Add(lambda tc: tc.ParamListNode([4,2,2,3]).Result(7)) \
        .Add(lambda tc: tc.ParamListNode([1,100000]).Result(100001)) \
        .Run()