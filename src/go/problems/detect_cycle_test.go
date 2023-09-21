// https://leetcode.com/problems/linked-list-cycle-ii/

package problems

import "testing"

func TestDetectCycle(t *testing.T) {
	tail := ListNode{
		Val: 4,
	};
	cycle := ListNode{
		Val: 2,
		Next: &ListNode{
			Val: 0,
			Next: &tail,
		},
	}
	tail.Next = &cycle
	head := ListNode{
		Val: 3,
		Next: &cycle,
	}

	result := DetectCycle(&head)
	t.Log(result)
}

func DetectCycle(head *ListNode) *ListNode {
	slow := head
	fast := head

	for fast != nil && fast.Next != nil {
		slow = slow.Next
		fast = fast.Next.Next
		if slow == fast {
			for head != slow {
				head = head.Next
				slow = slow.Next
			}

			return head
		}
	}

	return nil
}
