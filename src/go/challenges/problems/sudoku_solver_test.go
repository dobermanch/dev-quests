// https://leetcode.com/problems/sudoku-solver

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type SudokuSolver struct{}

func TestSudokuSolver(t *testing.T) {
	gen := core.TestSuite[SudokuSolver]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([][]byte{{'5', '3', '.', '.', '7', '.', '.', '.', '.'},
			{'6', '.', '.', '1', '9', '5', '.', '.', '.'},
			{'.', '9', '8', '.', '.', '.', '.', '6', '.'},
			{'8', '.', '.', '.', '6', '.', '.', '.', '3'},
			{'4', '.', '.', '8', '.', '3', '.', '.', '1'},
			{'7', '.', '.', '.', '2', '.', '.', '.', '6'},
			{'.', '6', '.', '.', '.', '.', '2', '8', '.'},
			{'.', '.', '.', '4', '1', '9', '.', '.', '5'},
			{'.', '.', '.', '.', '8', '.', '.', '7', '9'},
		},
		).Result(
			[][]byte{
				{'5', '3', '4', '6', '7', '8', '9', '1', '2'},
				{'6', '7', '2', '1', '9', '5', '3', '4', '8'},
				{'1', '9', '8', '3', '4', '2', '5', '6', '7'},
				{'8', '5', '9', '7', '6', '1', '4', '2', '3'},
				{'4', '2', '6', '8', '5', '3', '7', '9', '1'},
				{'7', '1', '3', '9', '2', '4', '8', '5', '6'},
				{'9', '6', '1', '5', '3', '7', '2', '8', '4'},
				{'2', '8', '7', '4', '1', '9', '6', '3', '5'},
				{'3', '4', '5', '2', '8', '6', '1', '7', '9'},
			},
		)
	}).Run(t)
}

func (SudokuSolver) Solution(board [][]byte) [][]byte {
	size := len(board)
	cols := make([][]bool, size)
	rows := make([][]bool, size)
	blocks := make([][]bool, size)

	for i := 0; i < size; i++ {
		cols[i] = make([]bool, size)
		rows[i] = make([]bool, size)
		blocks[i] = make([]bool, size)
	}

	for row := 0; row < size; row++ {
		for col := 0; col < size; col++ {
			if board[row][col] == '.' {
				continue
			}
			val := board[row][col] - '1'
			cols[col][val] = true
			rows[row][val] = true
			blockIndex := (row/3)*3 + (col / 3)
			blocks[blockIndex][val] = true
		}
	}

	var solve func(row, col int) bool
	solve = func(row, col int) bool {
		if row >= size {
			return true
		}
		if col >= size {
			return solve(row+1, 0)
		}
		if board[row][col] != '.' {
			return solve(row, col+1)
		}

		for val := byte(0); val < 9; val++ {
			blockIndex := (row/3)*3 + (col / 3)
			if cols[col][val] || rows[row][val] || blocks[blockIndex][val] {
				continue
			}

			cols[col][val] = true
			rows[row][val] = true
			blocks[blockIndex][val] = true
			board[row][col] = val + '1'

			if solve(row, col+1) {
				return true
			}

			board[row][col] = '.'
			cols[col][val] = false
			rows[row][val] = false
			blocks[blockIndex][val] = false
		}
		return false
	}

	solve(0, 0)

	return board
}
