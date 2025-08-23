// https://leetcode.com/problems/transpose-matrix

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type Transpose struct{}

func TestTranspose(t *testing.T) {
	gen := core.TestSuite[Transpose]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([][]int{{1, 2, 3}, {4, 5, 6}, {7, 8, 9}}).Result([][]int{{1, 4, 7}, {2, 5, 8}, {3, 6, 9}})
	}).Add(func(tc *core.TestCase) {
		tc.Param([][]int{{1, 2, 3}, {4, 5, 6}}).Result([][]int{{1, 4}, {2, 5}, {3, 6}})
	}).Run(t)
}

func (Transpose) Solution(matrix [][]int) [][]int {
	columns := len(matrix[0])
	rows := len(matrix)
	result := make([][]int, columns)

	for col := 0; col < columns; col++ {
		result[col] = make([]int, rows)
		for row := 0; row < rows; row++ {
			result[col][row] = matrix[row][col]
		}
	}

	return result
}
