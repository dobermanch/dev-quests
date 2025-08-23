// https://leetcode.com/problems/minimum-path-sum

package problems

import (
	"testing"
	"github.com/dobermanch/leetcode/core"
)

type MinPathSum struct{}

func TestMinPathSum(t *testing.T) {
	gen := core.TestSuite[MinPathSum]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([][]int{{1,3,1},{1,5,1},{4,2,1}}).Result(7)
	}).Add(func(tc *core.TestCase) {
		tc.Param([][]int{{1,2,3},{4,5,6}}).Result(12)
	}).Run(t)
}

func (MinPathSum) Solution(grid [][]int) int {
    min := func(left int, right int) int {
        if left < right {
            return left
        }

        return right
    }

    height := len(grid)
    width := len(grid[0])

    for row := 0; row < height; row++ {
        for col := 0; col < width; col++ {
            if row == 0 && col == 0 {
                continue;
            }

            if col == 0 {
                grid[row][col] = grid[row][col] + grid[row - 1][col]
            } else if row == 0 {
                grid[row][col] = grid[row][col] + grid[row][col - 1]
            } else {
                grid[row][col] = min(grid[row][col] + grid[row][col - 1], grid[row][col] + grid[row - 1][col])
            }
        }
    }

    return grid[height - 1][width - 1]
}
