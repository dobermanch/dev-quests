// https://leetcode.com/problems/count-negative-numbers-in-a-sorted-matrix
package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type CountNegativeNumbersInASortedMatrix struct{}

func TestCountNegativeNumbersInASortedMatrix(t *testing.T) {
	gen := core.TestSuite[CountNegativeNumbersInASortedMatrix]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([][]int{{4, 3, 2, -1}, {3, 2, 1, -1}, {1, 1, -1, -2}, {-1, -1, -2, -3}}).Result(8)
	}).Add(func(tc *core.TestCase) {
		tc.Param([][]int{{3, 2}, {1, 0}}).Result(0)
	}).Add(func(tc *core.TestCase) {
		tc.Param([][]int{{3, 2}, {-3, -3}, {-3, -3}, {-3, -3}}).Result(6)
	}).Run(t)
}

func (CountNegativeNumbersInASortedMatrix) Solution(grid [][]int) int {
	result := 0
	height := len(grid)
	width := len(grid[0])

	for row := 0; row < height; row++ {
		for col := width - 1; col >= 0; col-- {
			if grid[row][col] < 0 {
				result += height - row
				width = col
			} else {
				width = col + 1
				break
			}
		}
	}

	return result
}
