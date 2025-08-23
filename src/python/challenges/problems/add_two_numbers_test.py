# https://leetcode.com/problems/add-two-numbers/

from typing import Optional

from models.list_node import *
from core.problem_base import *

class AddTwoNumbers(ProblemBase):
    def Solution(self, l1: Optional[ListNode], l2: Optional[ListNode]) -> Optional[ListNode]:
        node1 = l1
        node2 = l2
        result = ListNode()
        current = result
        carry = 0

        while node1 or node2 or carry > 0:
            num1 = node1.val if node1 else 0
            num2 = node2.val if node2 else 0
            sum = carry + num1 + num2
            carry = sum // 10
            current.next = ListNode(sum % 10)
        
            current = current.next
            node1 = node1.next if node1 else None
            node2 = node2.next if node2 else None

        return result.next

if __name__ == '__main__':
    TestGen(AddTwoNumbers) \
        .Add(lambda tc: tc.ParamListNode([2,4,3]).ParamListNode([5,6,4]).ResultListNode([7,0,8])) \
        .Add(lambda tc: tc.ParamListNode([0]).ParamListNode([0]).ResultListNode([0])) \
        .Add(lambda tc: tc.ParamListNode([9,9,9,9,9,9,9]).ParamListNode([9,9,9,9]).ResultListNode([8,9,9,9,0,0,0,1])) \
        .Run()