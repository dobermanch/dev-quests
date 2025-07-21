# https://leetcode.com/problems/remove-linked-list-elements/

from typing import Optional
from models.list_node import ListNode
from core.problem_base import *

class RemoveElements(ProblemBase):
    def Solution(self, head: Optional[ListNode], val: int) -> Optional[ListNode]:
        prev = head
        current = head
        while current:
            if current.val != val:
                prev = current
            else:
                prev.next = current.next

            current = current.next

        return head if not head or head.val != val else head.next

if __name__ == '__main__':
    TestGen(RemoveElements) \
        .Add(lambda tc: tc.ParamListNode([1,2,6,3,4,5,6]).Param(6).ResultListNode([1,2,3,4,5])) \
        .Add(lambda tc: tc.ParamListNode([]).Param(1).ResultListNode([])) \
        .Add(lambda tc: tc.ParamListNode([7,7,7,7]).Param(7).ResultListNode([])) \
        .Run()
