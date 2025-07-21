// https://leetcode.com/problems/maximum-twin-sum-of-a-linked-list

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type PairSum struct{}

func TestPairSum(t *testing.T) {
	gen := core.TestSuite[PairSum]{}
	gen.Add(func(tc *core.TestCase) {
		l1 := ListNode{
			Val: 5,
			Next: &ListNode{
				Val: 4,
				Next: &ListNode{
					Val: 2,
					Next: &ListNode{
						Val: 1,
					},
				},
			},
		}

		tc.Param(l1).Result(6)
	}).Run(t)
}

func (PairSum) Solution(head *ListNode) int {
	slow := head
	fast := head

	for fast != nil && fast.Next != nil {
		slow = slow.Next
		fast = fast.Next.Next
	}

	var tail *ListNode
	for slow != nil {
		next := slow.Next
		slow.Next = tail
		tail = slow
		slow = next
	}

	max := 0
	for tail != nil {
		sum := tail.Val + head.Val
		if sum > max {
			max = sum
		}

		head = head.Next
		tail = tail.Next
	}

	return max
}
