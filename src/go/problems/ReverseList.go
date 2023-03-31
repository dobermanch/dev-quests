// https://leetcode.com/problems/reverse-linked-list

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
