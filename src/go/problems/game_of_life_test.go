// https://leetcode.com/problems/game-of-life

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type GameOfLife struct{}

func TestGameOfLife(t *testing.T) {
	gen := core.TestSuite[GameOfLife]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([][]int{{0, 1, 0}, {0, 0, 1}, {1, 1, 1}, {0, 0, 0}}).Result([][]int{{0, 0, 0}, {1, 0, 1}, {0, 1, 1}, {0, 1, 0}})
	}).Add(func(tc *core.TestCase) {
		tc.Param([][]int{{1, 1}, {1, 0}}).Result([][]int{{1, 1}, {1, 1}})
	}).Run(t)
}

func (GameOfLife) Solution(board [][]int) [][]int {
	directions := [][]int{
		{-1, -1}, {-1, 0}, {-1, 1},
		{0, -1}, {0, 1},
		{1, -1}, {1, 0}, {1, 1},
	}

	count := len(directions)
	rows := len(board)
	cols := len(board[0])

	for row := 0; row < rows; row++ {
		for col := 0; col < cols; col++ {
			neighbors := 0

			for i := 0; i < count; i++ {
				y := row + directions[i][0]
				x := col + directions[i][1]

				if y >= 0 && y < rows &&
					x >= 0 && x < cols &&
					(board[y][x] == 1 || board[y][x] >= 20) {
					neighbors++
				}
			}

			if board[row][col] == 0 {
				board[row][col] = neighbors + 10
			} else {
				board[row][col] = neighbors + 20
			}
		}
	}

	for row := 0; row < rows; row++ {
		for col := 0; col < cols; col++ {
			neighbors := 0
			if board[row][col] >= 20 {
				neighbors = board[row][col] - 20
			} else {
				neighbors = board[row][col] - 10
			}

			if neighbors < 2 || neighbors > 3 {
				board[row][col] = 0
			} else if neighbors == 3 && board[row][col] < 20 {
				board[row][col] = 1
			} else if board[row][col] >= 20 {
				board[row][col] = 1
			} else {
				board[row][col] = 0
			}
		}
	}

	return board
}
