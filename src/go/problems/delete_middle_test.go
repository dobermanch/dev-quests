// https://leetcode.com/problems/delete-the-middle-node-of-a-linked-list/

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type DeleteMiddle struct{}

func TestDeleteMiddle(t *testing.T) {
	gen := core.TestSuite[DeleteMiddle]{}
	gen.Add(func(tc *core.TestCase) {
		l1 := ListNode{
			Val: 1,
			Next: &ListNode{
				Val: 2,
				Next: &ListNode{
					Val: 3,
					Next: &ListNode{
						Val: 4,
					},
				},
			},
		}

		result := ListNode{
			Val: 1,
			Next: &ListNode{
				Val: 2,
				Next: &ListNode{
					Val: 4,
				},
			},
		}
		tc.Param(l1).Result(result)
	}).Run(t)
}

func (DeleteMiddle) Solution(head *ListNode) *ListNode {
	if head == nil || head.Next == nil {
		return nil
	}

	slow := head
	fast := head.Next.Next

	for fast != nil && fast.Next != nil {
		slow = slow.Next
		fast = fast.Next.Next
	}

	slow.Next = slow.Next.Next

	return head
}
