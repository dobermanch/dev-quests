// https://leetcode.com/problems/maximum-depth-of-binary-tree/

package problems

import (
	"testing"
)

func TestMaxDepth(t *testing.T) {
	var node = TreeNode{Val: 1, Left: &TreeNode{Val: 2}, Right: &ListNode{Val: 3}}
	
	result := MaxDepth(node)
	t.Log(result)
}

func MaxDepth(root *TreeNode) int {
	return Dfs(root, 0)
}

func Dfs(node *TreeNode, depth int) int {
	if node == nil {
		return depth
	}

	left := Dfs(node.Left, depth)
	right := Dfs(node.Right, depth)

	return 1 + max(left, right)
}

func max(left int, right int) int {
	if left > right {
		return left
	}

	return right
}
