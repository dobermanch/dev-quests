// https://leetcode.com/problems/surrounded-regions

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type Solve struct{}

func TestSolve(t *testing.T) {
	gen := core.TestSuite[Solve]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([][]byte{{'X', 'X', 'X', 'X'}, {'X', 'O', 'O', 'X'}, {'X', 'X', 'O', 'X'}, {'X', 'O', 'X', 'X'}}).Result([][]byte{{'X', 'X', 'X', 'X'}, {'X', 'X', 'X', 'X'}, {'X', 'X', 'X', 'X'}, {'X', 'O', 'X', 'X'}})
	}).Add(func(tc *core.TestCase) {
		tc.Param([][]byte{{'X', 'X', 'X', 'X'}, {'X', 'O', 'O', 'X'}, {'X', 'X', 'O', 'X'}, {'X', 'O', 'O', 'X'}}).Result([][]byte{{'X', 'X', 'X', 'X'}, {'X', 'O', 'O', 'X'}, {'X', 'X', 'O', 'X'}, {'X', 'O', 'O', 'X'}})
	}).Run(t)
}

func (Solve) Solution(board [][]byte) [][]byte {
	rows := len(board)
	cols := len(board[0])

	var mark func([][]byte, int, int)
	mark = func(board [][]byte, y int, x int) {
		if y < 0 || y >= rows ||
			x < 0 || x >= cols ||
			board[y][x] != 'O' {
			return
		}

		board[y][x] = 'o'

		mark(board, y+1, x)
		mark(board, y-1, x)
		mark(board, y, x+1)
		mark(board, y, x-1)
	}

	for col := 0; col < cols; col++ {
		mark(board, 0, col)
		mark(board, rows-1, col)
	}

	for row := 0; row < rows; row++ {
		mark(board, row, 0)
		mark(board, row, cols-1)
	}

	for row := 0; row < rows; row++ {
		for col := 0; col < cols; col++ {
			if board[row][col] == 'o' {
				board[row][col] = 'O'
			} else {
				board[row][col] = 'X'
			}
		}
	}

	return board
}
