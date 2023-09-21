// https://leetcode.com/problems/maximum-depth-of-binary-tree/

package problems

import (
	"testing"
)

func TestMaxDepth(t *testing.T) {
	var node = TreeNode{Val: 1, Left: &TreeNode{Val: 2}, Right: &TreeNode{Val: 3}}
	
	result := MaxDepth(&node)
	t.Log(result)
}

func MaxDepth(root *TreeNode) int {
	return Dfs2(root, 0)
}

func Dfs2(node *TreeNode, depth int) int {
	if node == nil {
		return depth
	}

	left := Dfs2(node.Left, depth)
	right := Dfs2(node.Right, depth)

	return 1 + max1(left, right)
}

func max1(left int, right int) int {
	if left > right {
		return left
	}

	return right
}
