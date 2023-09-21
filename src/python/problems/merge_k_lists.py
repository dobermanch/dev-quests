# https://leetcode.com/problems/merge-k-sorted-lists/

from typing import Optional
from models.list_node import ListNode


class MergeKLists:
    def Solution(self, lists: list[Optional[ListNode]]) -> Optional[ListNode]:
        if len(lists) == 0:
            return

        def Merge(toMerge: List[Optional[ListNode]], index1: int, index2: int) -> Optional[ListNode]:
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


MergeKLists().Solution([ListNode(1, ListNode(2, ListNode(4))), ListNode(1, ListNode(3, ListNode(4))), ListNode(1, ListNode(2, ListNode(4))), ListNode(1, ListNode(3, ListNode(4)))])
