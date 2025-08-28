#https://leetcode.com/problems/remove-duplicates-from-sorted-list-ii/

from typing import Optional
from models.list_node import ListNode
from core.problem_base import *

class DeleteDuplicates(ProblemBase):
    def Solution(self, head: Optional[ListNode]) -> Optional[ListNode]:
        prev = ListNode(next=head)
        head = prev
        current = head.next
        remove = False
        while current:
            if current.next and current.val == current.next.val:
                prev.next = current.next
                remove = True
            elif remove:
                prev.next = current.next
                remove = False
            else:
                prev = current

            current = current.next

        return head.next

if __name__ == '__main__':
    TestGen(DeleteDuplicates) \
        .Add(lambda tc: tc.ParamListNode([1,2,3,3,4,4,5]).ResultListNode([1,2,5])) \
        .Run()
