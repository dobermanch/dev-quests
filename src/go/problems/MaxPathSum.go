// https://leetcode.com/problems/binary-tree-maximum-path-sum/

package problems

import (
	"testing"
)

func TestMaxPathSum(t *testing.T) {
	var node = TreeNode{Val: 1, Left: &TreeNode{Val: 2}, Right: &ListNode{Val: 3}}
	
	result := MaxPathSum(node)
	t.Log(result)
}

var result int

func MaxPathSum(root *TreeNode) int {
    result = root.Val
	Dfs(root)

	return result
}

func Dfs(node *TreeNode) int {
	if node == nil {
		return 0
	}

	left := Dfs(node.Left)
	right := Dfs(node.Right)

	nodeMax := max(node.Val + left, node.Val + right)
	nodeMax = max(nodeMax, node.Val)

	result = max(result, nodeMax)
	result = max(result, left + right + node.Val)

	return nodeMax
}

func max(left int, right int) int {
	if left > right {
		return left
	}

	return right
}