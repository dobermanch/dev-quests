// https://leetcode.com/problems/merge-k-sorted-lists/

package problems

import (
	"testing"
)

func TestMergeKLists(t *testing.T) {
	var node1 = ListNode{Val: 1, Next: &ListNode{Val: 2, Next: &ListNode{Val: 3, Next: &ListNode{Val: 4, Next: &ListNode{Val: 5}}}}}
	var node2 = ListNode{Val: 1, Next: &ListNode{Val: 2, Next: &ListNode{Val: 3, Next: &ListNode{Val: 4, Next: &ListNode{Val: 5}}}}}

	result := MergeKLists([]*ListNode{&node1, &node2})
	t.Log(result)
}

func MergeKLists(lists []*ListNode) *ListNode {
	if lists == nil || len(lists) == 0 {
		return nil
	}

	return merge(lists, 0, len(lists)-1)
}

func merge(lists []*ListNode, index1 int, index2 int) *ListNode {
	if index1 == index2 {
		return lists[index1]
	}

	diff := (index1 + index2) / 2
	list1 := merge(lists, index1, diff)
	list2 := merge(lists, diff+1, index2)

	result := new(ListNode)
	current := result

	for list1 != nil && list2 != nil {
		if list1.Val <= list2.Val {
			current.Next = list1
			list1 = list1.Next
		} else {
			current.Next = list2
			list2 = list2.Next
		}

		current = current.Next
	}

	if list1 == nil {
		current.Next = list2
	} else {
		current.Next = list1
	}

	return result.Next
}
