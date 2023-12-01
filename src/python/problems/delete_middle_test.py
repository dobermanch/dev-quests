# https://leetcode.com/problems/delete-the-middle-node-of-a-linked-list/

from typing import Optional
from core.problem_base import *
from models.list_node import *

class DeleteMiddle(ProblemBase):
    def Solution(self, head: Optional[ListNode]) -> Optional[ListNode]:
        if not head.next:
            return None

        slow = head
        fast = head.next.next

        while fast and fast.next:
            slow = slow.next
            fast = fast.next.next

        slow.next = slow.next.next

        return head


if __name__ == '__main__':
    TestGen(DeleteMiddle) \
        .Add(lambda tc: tc.ParamListNode([1,3,4,7,1,2,6]).ResultListNode([1,3,4,1,2,6])) \
        .Add(lambda tc: tc.ParamListNode([1,2,3,4]).ResultListNode([1,2,4])) \
        .Add(lambda tc: tc.ParamListNode([2,1]).ResultListNode([2])) \
        .Run()