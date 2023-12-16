// https://leetcode.com/problems/n-queens-ii

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type TotalNQueens struct{}

func TestTotalNQueens(t *testing.T) {
	gen := core.TestSuite[TotalNQueens]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param(4).Result(2)
	}).Add(func(tc *core.TestCase) {
		tc.Param(1).Result(1)
	}).Add(func(tc *core.TestCase) {
		tc.Param(2).Result(0)
	}).Add(func(tc *core.TestCase) {
		tc.Param(3).Result(0)
	}).Add(func(tc *core.TestCase) {
		tc.Param(9).Result(352)
	}).Run(t)
}

func (TotalNQueens) Solution(n int) int {
	leftDiagMap := 0
	rightDiagMap := 0
	colMap := 0

	var placeQueens func(int) int
	placeQueens = func(row int) int {
		if row >= n {
			return 1
		}

		result := 0
		for col := 0; col < n; col++ {
			leftDiagShift := row + col
			rightDiagShift := n + (row - col)

			if (colMap&(1<<col)) != 0 ||
				(leftDiagMap&(1<<leftDiagShift)) != 0 ||
				(rightDiagMap&(1<<rightDiagShift)) != 0 {
				continue
			}

			colMap |= 1 << col
			leftDiagMap |= 1 << leftDiagShift
			rightDiagMap |= 1 << rightDiagShift

			result += placeQueens(row + 1)

			colMap &= ^(1 << col)
			leftDiagMap &= ^(1 << leftDiagShift)
			rightDiagMap &= ^(1 << rightDiagShift)
		}

		return result
	}

	return placeQueens(0)
}
