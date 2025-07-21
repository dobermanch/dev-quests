// https://leetcode.com/problems/binary-tree-inorder-traversal

package problems

import (
	"testing"
	"github.com/dobermanch/leetcode/core"
)

type InorderTraversal struct{}

func TestInorderTraversal(t *testing.T) {
	gen := core.TestSuite[InorderTraversal]{}
	gen.Add(func(tc *core.TestCase) {
		node := &TreeNode{ Val: 1, Right: &TreeNode{ Val: 2, Left: &TreeNode{Val: 3}}}

		tc.Param(node).Result([]int{1,3,2})
	}).Run(t)
}

func (InorderTraversal) Solution1(root *TreeNode) []int {
	result := []int{}

	var dfs func(node *TreeNode)
	dfs = func(node *TreeNode) {
		if node == nil {
			return
		}
		
		dfs(node.Left)

		result = append(result, node.Val)

		dfs(node.Right)
	}

	dfs(root)

	return result
}

func (InorderTraversal) Solution2(root *TreeNode) []int {
	result := []int{}
	stack := []*TreeNode{}

	node := root
	for node != nil || len(stack) > 0 {
		if node != nil {
			stack = append(stack, node)
			node = node.Left
		} else {
			var pop = stack[len(stack) - 1]		
			result = append(result, pop.Val)
			node = pop.Right
			stack = stack[:len(stack) - 1]
		}
	}

	return result
}
