# https://leetcode.com/problems/reverse-linked-list/
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
    TestGen(ReverseList) \
        .Add(lambda tc: tc.ParamListNode([1,2,3,4,5]).ResultListNode([5,4,3,2,1])) \
        .Add(lambda tc: tc.ParamListNode([1,2]).ResultListNode([2,1])) \
        .Add(lambda tc: tc.ParamListNode([]).ResultListNode([])) \
        .Run()
