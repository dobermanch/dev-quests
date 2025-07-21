// https://leetcode.com/problems/linked-list-cycle/

package problems

import (
	"testing"
)

func TestHasCycle(t *testing.T) {
	head := ListNode{
		Val: 3,
		Next: &ListNode{
			Val: 2,
			Next: &ListNode{
				Val: 0,
				Next: &ListNode{
					Val: -4,
				},
			},
		},
	}

	result := HasCycle(&head)
	t.Log(result)
}

func HasCycle(head *ListNode) bool {
	slow := head
	var fast *ListNode

	if head != nil {
		fast = head.Next
	}

	for slow != nil && fast != nil && fast.Next != nil {
		if slow == fast {
			return true
		}

		slow = slow.Next
		fast = fast.Next.Next
	}

	return false
}
