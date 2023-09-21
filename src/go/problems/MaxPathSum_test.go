// https://leetcode.com/problems/binary-tree-maximum-path-sum/

package problems

import (
	"testing"
)

func TestMaxPathSum(t *testing.T) {
	var node = TreeNode{Val: 1, Left: &TreeNode{Val: 2}, Right: &TreeNode{Val: 3}}
	
	result := MaxPathSum(&node)
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

	nodeMax := max2(node.Val + left, node.Val + right)
	nodeMax = max2(nodeMax, node.Val)

	result = max2(result, nodeMax)
	result = max2(result, left + right + node.Val)

	return nodeMax
}

func max2(left int, right int) int {
	if left > right {
		return left
	}

	return right
}