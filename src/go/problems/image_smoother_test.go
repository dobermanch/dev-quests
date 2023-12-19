// https://leetcode.com/problems/image-smoother

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type ImageSmoother struct{}

func TestImageSmoother(t *testing.T) {
	gen := core.TestSuite[ImageSmoother]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([][]int{{1, 1, 1}, {1, 0, 1}, {1, 1, 1}}).Result([][]int{{0, 0, 0}, {0, 0, 0}, {0, 0, 0}})
	}).Add(func(tc *core.TestCase) {
		tc.Param([][]int{{100, 200, 100}, {200, 50, 200}, {100, 200, 100}}).Result([][]int{{137, 141, 137}, {141, 138, 141}, {137, 141, 137}})
	}).Run(t)
}

func (ImageSmoother) Solution(img [][]int) [][]int {
	directions := [][]int{
		{-1, -1}, {-1, 0}, {-1, 1},
		{0, -1}, {0, 0}, {0, 1},
		{1, -1}, {1, 0}, {1, 1},
	}

	count := len(directions)
	rows := len(img)
	cols := len(img[0])
	result := make([][]int, rows)

	for row := 0; row < rows; row++ {
		result[row] = make([]int, cols)

		for col := 0; col < cols; col++ {
			neighbors := 0

			for i := 0; i < count; i++ {
				y := row + directions[i][0]
				x := col + directions[i][1]

				if y >= 0 && y < rows && x >= 0 && x < cols {
					result[row][col] += img[y][x]
					neighbors++
				}
			}

			result[row][col] /= neighbors
		}
	}

	return result
}
