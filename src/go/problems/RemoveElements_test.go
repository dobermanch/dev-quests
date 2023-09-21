// https://leetcode.com/problems/remove-linked-list-elements

package problems

func RemoveElements(head *ListNode, val int) *ListNode {
	prev := head
	current := head

	for current != nil {
		if current.Val != val {
			prev = current
		} else {
			prev.Next = current.Next
		}

		current = current.Next
	}

	if head != nil && head.Val == val {
		return head.Next
	}

	return head
}
