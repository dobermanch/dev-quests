// https://leetcode.com/problems/remove-linked-list-elements

package problems

func ReverseList(head *ListNode) *ListNode {
	if head == nil {
		return nil
	}

	var result *ListNode
	current := head

	for current != nil {
		next := current.Next
		current.Next = result
		result = current
		current = next
	}

	return result
}
