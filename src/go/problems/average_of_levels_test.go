// https://leetcode.com/problems/average-of-levels-in-binary-tree/

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type AverageOfLevels struct{}

func TestAverageOfLevels(t *testing.T) {
	gen := core.TestSuite[AverageOfLevels]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param(&TreeNode{Val: 3, Left: &TreeNode{Val: 9}, Right: &TreeNode{Val: 20, Left: &TreeNode{Val: 15}, Right: &TreeNode{Val: 7}}}).Result([]float64{3.00000, 14.50000, 11.00000})
	}).Run(t)
}

func (AverageOfLevels) Solution(root *TreeNode) []float64 {
	queue := []*TreeNode{root}
	result := make([]float64, 0)

	for len(queue) > 0 {
		length := len(queue)
		sum := 0
		for i := 0; i < length; i++ {
			node := queue[0]
			queue = queue[1:]
			if node.Left != nil {
				queue = append(queue, node.Left)
			}

			if node.Right != nil {
				queue = append(queue, node.Right)
			}

			sum += node.Val
		}

		average := float64(sum) / float64(length)
		result = append(result, average)
	}

	return result
}
