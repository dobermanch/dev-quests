// https://leetcode.com/problems/count-complete-tree-nodes/

package problems

import (
	"math"
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type CountNodes struct{}

func TestCountNodes(t *testing.T) {
	gen := core.TestSuite[CountNodes]{}
	gen.Add(func(tc *core.TestCase) {
		root := &TreeNode{
			Val:   1,
			Left:  &TreeNode{Val: 2, Left: &TreeNode{Val: 4}, Right: &TreeNode{Val: 5}},
			Right: &TreeNode{Val: 3, Left: &TreeNode{Val: 6}},
		}
		tc.Param(root).Result(6)
	}).Run(t)
}

func (CountNodes) Solution(root *TreeNode) int {
	var count func(root *TreeNode) int
	count = func(root *TreeNode) int {
		if root == nil {
			return 0
		}

		leftLevel := 0.
		node := root
		for node != nil {
			node = node.Left
			leftLevel++
		}

		rightLevel := 0.
		node = root
		for node != nil {
			node = node.Right
			rightLevel++
		}

		if leftLevel == rightLevel {
			return int(math.Pow(2.0, leftLevel)) - 1
		}

		return 1 + count(root.Left) + count(root.Right)
	}

	return count(root)
}
