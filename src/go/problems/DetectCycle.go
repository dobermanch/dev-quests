// https://leetcode.com/problems/linked-list-cycle-ii/

package problems

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
