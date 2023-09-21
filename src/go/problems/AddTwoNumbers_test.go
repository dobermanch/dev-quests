// https://leetcode.com/problems/add-two-numbers/

package problems

import "testing"

func TestAddTwoNumbers(t *testing.T) {
	l1 := ListNode{
		Val: 2,
		Next: &ListNode{
			Val: 4,
			Next: &ListNode{
				Val: 3,
			},
		},
	}

	var l2 = ListNode{
		Val: 5,
		Next: &ListNode{
			Val: 6,
			Next: &ListNode{
				Val: 4,
			},
		},
	}

	result := addTwoNumbers(&l1, &l2)
	t.Log(result)
}

func addTwoNumbers(l1 *ListNode, l2 *ListNode) *ListNode {
	node1 := l1
	node2 := l2
	result := &ListNode{}
	current := result
	var carry = 0

	for node1 != nil || node2 != nil || carry > 0 {
		var sum = carry
		if node1 != nil {
			sum = sum + node1.Val
			node1 = node1.Next
		}

		if node2 != nil {
			sum = sum + node2.Val
			node2 = node2.Next
		}

		carry = sum / 10
		current.Next = &ListNode{Val: sum % 10}
		current = current.Next
	}

	return result.Next
}
