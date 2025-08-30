// https://leetcode.com/problems/unique-paths-ii

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type UniquePathsIi struct{}

func TestUniquePathsIi(t *testing.T) {
	gen := core.TestSuite[UniquePathsIi]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([][]int{{0, 0, 0}, {0, 1, 0}, {0, 0, 0}}).Result(2)
	}).Add(func(tc *core.TestCase) {
		tc.Param([][]int{{0, 0, 0, 0}, {0, 1, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}}).Result(8)
	}).Add(func(tc *core.TestCase) {
		tc.Param([][]int{{1}}).Result(0)
	}).Add(func(tc *core.TestCase) {
		tc.Param([][]int{{0}}).Result(1)
	}).Run(t)
}

func (UniquePathsIi) Solution(obstacleGrid [][]int) int {
	width := len(obstacleGrid)
	height := len(obstacleGrid[0])

	for row := 0; row < width; row++ {
		for col := 0; col < height; col++ {
			if obstacleGrid[row][col] == 1 {
				obstacleGrid[row][col] = 0
				continue
			}

			if row == 0 && col == 0 {
				obstacleGrid[row][col] = 1
				continue
			}

			if row-1 >= 0 {
				obstacleGrid[row][col] += obstacleGrid[row-1][col]
			}

			if col-1 >= 0 {
				obstacleGrid[row][col] += obstacleGrid[row][col-1]
			}
		}
	}

	return obstacleGrid[width-1][height-1]
}
