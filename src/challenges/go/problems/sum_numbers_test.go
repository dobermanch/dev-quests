// https://leetcode.com/problems/sum-root-to-leaf-numbers

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type SumNumbers struct{}

func TestSumNumbers(t *testing.T) {
	gen := core.TestSuite[SumNumbers]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param(&TreeNode{Val: 1, Left: &TreeNode{Val: 2}, Right: &TreeNode{Val: 3}}).Result(25)
	}).Add(func(tc *core.TestCase) {
		tc.Param(&TreeNode{Val: 4, Left: &TreeNode{Val: 9, Left: &TreeNode{Val: 5}, Right: &TreeNode{Val: 1}}, Right: &TreeNode{Val: 0}}).Result(1026)
	}).Run(t)
}

func (SumNumbers) Solution1(root *TreeNode) int {
	stack := []*TreeNode{}
	sum := 0

	node := root
	for node != nil || len(stack) > 0 {
		prevNode := node
		if node != nil {
			if node.Left == nil && node.Right == nil {
				sum += node.Val
			}

			stack = append(stack, node)
			node = node.Left
		} else {
			prevNode = stack[len(stack)-1]
			stack = stack[:len(stack)-1]
			node = prevNode.Right
		}

		if node != nil && prevNode != nil {
			node.Val += prevNode.Val * 10
		}
	}

	return sum
}

func (SumNumbers) Solution2(root *TreeNode) int {
	var sum func(*TreeNode, int) int
	sum = func(node *TreeNode, accum int) int {
		if node == nil {
			return 0
		}

		accum += node.Val

		if node.Left == nil && node.Right == nil {
			return accum
		}

		accum *= 10

		return sum(node.Left, accum) + sum(node.Right, accum)
	}

	return sum(root, 0)
}
