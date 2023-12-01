# https://leetcode.com/problems/merge-k-sorted-lists/

from typing import Optional
from models.list_node import ListNode
from core.problem_base import *

class MergeKLists(ProblemBase):
    def Solution(self, lists: list[Optional[ListNode]]) -> Optional[ListNode]:
        if len(lists) == 0:
            return

        def Merge(toMerge, index1, index2):
            if index1 == index2:
                return toMerge[index1]

            diff = (index1 + index2) // 2
            list1 = Merge(toMerge, index1, diff)
            list2 = Merge(toMerge, diff + 1, index2)

            result = ListNode()
            current = result
            while list1 and list2:
                if list1.val < list2.val:
                    current.next = list1
                    list1 = list1.next
                else:
                    current.next = list2
                    list2 = list2.next
                current = current.next

            current.next = list1 if list1 else list2

            return result.next

        return Merge(lists, 0, len(lists) - 1)

if __name__ == '__main__':
    TestGen(MergeKLists) \
        .Add(lambda tc: tc.Param([ListNode.Create([1,4,5]),ListNode.Create([1,3,4]),ListNode.Create([2,6])]).ResultListNode([1,1,2,3,4,4,5,6])) \
        .Run()
