// https://leetcode.com/problems/subtree-of-another-tree/

package problems

import (
	"testing"
)

func TestIsSubtree(t *testing.T) {
	var node1 = TreeNode{Val: 1, Left: &TreeNode{Val: 2}, Right: &ListNode{Val: 3}}
	var node2 = TreeNode{Val: 1, Left: &TreeNode{Val: 2}, Right: &ListNode{Val: 3}}
	
	result := IsSubtree(node1, node2)
	t.Log(result)
}

func IsSubtree(root *TreeNode, subRoot *TreeNode) bool {
	return Dfs(root, subRoot, false)
}

func Dfs(tree1 *TreeNode, tree2 *TreeNode, checking bool) bool {
	if tree1 == nil && tree2 == nil {
		return true
	}

	if tree1 == nil || tree2 == nil {
		return false
	}

	result := tree1.Val == tree2.Val
	if result {
		result = Dfs(tree1.Left, tree2.Left, true) && Dfs(tree1.Right, tree2.Right, true)
	}

	if !result && !checking {
		result = Dfs(tree1.Left, tree2, false) || Dfs(tree1.Right, tree2, false)
    }

	return result
}