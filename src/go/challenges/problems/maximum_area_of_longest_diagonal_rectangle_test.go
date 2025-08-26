// https://leetcode.com/problems/maximum-area-of-longest-diagonal-rectangle

package problems

import (
	"math"
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type MaximumAreaOfLongestDiagonalRectangle struct{}

func TestMaximumAreaOfLongestDiagonalRectangle(t *testing.T) {
	gen := core.TestSuite[MaximumAreaOfLongestDiagonalRectangle]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([][]int{{9, 3}, {8, 6}}).Result(48)
	}).Add(func(tc *core.TestCase) {
		tc.Param([][]int{{3, 4}, {3, 4}}).Result(12)
	}).Run(t)
}

func (MaximumAreaOfLongestDiagonalRectangle) Solution(dimensions [][]int) int {
	maxDiagonal := 0.
	maxArea := 0

	for row := 0; row < len(dimensions); row++ {
		diagonal := math.Sqrt(math.Pow(float64(dimensions[row][0]), 2) + math.Pow(float64(dimensions[row][1]), 2))
		area := dimensions[row][0] * dimensions[row][1]

		if diagonal > maxDiagonal {
			maxDiagonal = diagonal
			maxArea = area
		} else if diagonal == maxDiagonal {
			if area > maxArea {
				maxArea = area
			}
		}
	}

	return maxArea
}
