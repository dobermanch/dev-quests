// https://leetcode.com/problems/special-positions-in-a-binary-matrix

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type NumSpecial struct{}

func TestNumSpecial(t *testing.T) {
	gen := core.TestSuite[NumSpecial]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([][]int{{1, 0, 0}, {0, 0, 1}, {1, 0, 0}}).Result(1)
	}).Add(func(tc *core.TestCase) {
		tc.Param([][]int{{1, 0, 0}, {0, 1, 0}, {0, 0, 1}}).Result(3)
	}).Run(t)
}

func (NumSpecial) Solution(mat [][]int) int {
	result := 0
	rowMap := make([]int, len(mat))
	colMap := make([]int, len(mat[0]))
	for row := 0; row < len(mat); row++ {
		for col := 0; col < len(mat[0]); col++ {
			if mat[row][col] == 1 {
				rowMap[row] += 1
				colMap[col] += 1
			}
		}
	}

	for row := 0; row < len(mat); row++ {
		if rowMap[row] != 1 {
			continue
		}

		for col := 0; col < len(mat[0]); col++ {
			if mat[row][col] == 1 && colMap[col] == 1 {
				result++
			}
		}
	}

	return result
}
