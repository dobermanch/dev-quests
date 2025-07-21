// https://leetcode.com/problems/valid-sudoku/

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type IsValidSudoku struct{}

func TestIsValidSudoku(t *testing.T) {
	gen := core.TestSuite[IsValidSudoku]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([][]string{
			{"5", "3", ".", ".", "7", ".", ".", ".", "."},
			{"6", ".", ".", "1", "9", "5", ".", ".", "."},
			{".", "9", "8", ".", ".", ".", ".", "6", "."},
			{"8", ".", ".", ".", "6", ".", ".", ".", "3"},
			{"4", ".", ".", "8", ".", "3", ".", ".", "1"},
			{"7", ".", ".", ".", "2", ".", ".", ".", "6"},
			{".", "6", ".", ".", ".", ".", "2", "8", "."},
			{".", ".", ".", "4", "1", "9", ".", ".", "5"},
			{".", ".", ".", ".", "8", ".", ".", "7", "9"}},
		).Result(true)
	}).Add(func(tc *core.TestCase) {
		tc.Param([][]string{
			{"8", "3", ".", ".", "7", ".", ".", ".", "."},
			{"6", ".", ".", "1", "9", "5", ".", ".", "."},
			{".", "9", "8", ".", ".", ".", ".", "6", "."},
			{"8", ".", ".", ".", "6", ".", ".", ".", "3"},
			{"4", ".", ".", "8", ".", "3", ".", ".", "1"},
			{"7", ".", ".", ".", "2", ".", ".", ".", "6"},
			{".", "6", ".", ".", ".", ".", "2", "8", "."},
			{".", ".", ".", "4", "1", "9", ".", ".", "5"},
			{".", ".", ".", ".", "8", ".", ".", "7", "9"}},
		).Result(false)
	}).Run(t)
}

func (IsValidSudoku) Solution(board [][]byte) bool {
	rows := len(board)
	cols := len(board[0])

	rowsMasks := [9]int{}
	colsMasks := [9]int{}
	boxMasks := [3][3]int{}

	for i := 0; i < rows; i++ {
		for j := 0; j < cols; j++ {
			if board[i][j] == '.' {
				continue
			}

			mask := 1 << board[i][j]
			if boxMasks[i/3][j/3]&mask != 0 {
				return false
			}
			boxMasks[i/3][j/3] |= mask

			if rowsMasks[i]&mask != 0 {
				return false
			}
			rowsMasks[i] |= mask

			if colsMasks[j]&mask != 0 {
				return false
			}
			colsMasks[j] |= mask
		}
	}

	return true
}
