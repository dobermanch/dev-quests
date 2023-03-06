// https://leetcode.com/problems/middle-of-the-linked-list/

package problems

func MiddleNode(head *ListNode) *ListNode {
	list := []*ListNode{}
	count := 0

	next := head
	for next != nil {
		list = append(list, next)
		count++
		next = next.Next
	}

	return list[count/2]
}
