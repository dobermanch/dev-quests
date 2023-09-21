// https://leetcode.com/problems/reorder-list/

package problems

import (
	"testing"
)

func TestReorderList(t *testing.T) {
	var node = ListNode{Val: 1, Next: &ListNode{Val: 2, Next: &ListNode{Val: 3, Next: &ListNode{Val: 4, Next: &ListNode{Val: 5}}}}}
	result := ReorderList(&node)
	t.Log(result)
}

func ReorderList(head *ListNode) *ListNode {
	slow := head
	fast := head.Next

	for fast != nil {
		slow = slow.Next
		if fast.Next != nil {
			fast = fast.Next.Next
		} else {
			fast = nil
		}
	}

	var reverse *ListNode

	for slow != nil {
		next := slow.Next
		slow.Next = reverse
		reverse = slow
		slow = next
	}

	lead := head
	tail := reverse
	for tail.Next != nil {
		nextLead := lead.Next
		nextTail := tail.Next

		lead.Next = tail
		tail.Next = nextLead

		lead = nextLead
		tail = nextTail
	}

	return head
}
