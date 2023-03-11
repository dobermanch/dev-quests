// https://leetcode.com/problems/linked-list-cycle/

package problems

import (
	"testing"
)

func TestHasCycle(t *testing.T) {
	result := HasCycle([]int{2, 7, 11, 15}, 9)
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
