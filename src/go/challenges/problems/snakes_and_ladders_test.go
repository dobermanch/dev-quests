// https://leetcode.com/problems/snakes-and-ladders

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type SnakesAndLadders struct{}

func TestSnakesAndLadders(t *testing.T) {
	gen := core.TestSuite[SnakesAndLadders]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([][]int{{-1, -1, -1, -1, -1, -1}, {-1, -1, -1, -1, -1, -1}, {-1, -1, -1, -1, -1, -1}, {-1, 35, -1, -1, 13, -1}, {-1, -1, -1, -1, -1, -1}, {-1, 15, -1, -1, -1, -1}}).Result(4)
	}).Add(func(tc *core.TestCase) {
		tc.Param([][]int{{1, 1, -1}, {1, 1, 1}, {-1, 1, 1}}).Result(-1)
	}).Run(t)
}

func (SnakesAndLadders) Solution(board [][]int) int {
	oneDBoard := make([]int, 0)
	reversedBoard := make([][]int, len(board))
	for i := range board {
		reversedBoard[len(board)-1-i] = board[i]
	}

	for i := 0; i < len(reversedBoard); i++ {
		if i%2 == 0 {
			for j := 0; j < len(reversedBoard[i]); j++ {
				oneDBoard = append(oneDBoard, reversedBoard[i][j])
			}
		} else {
			for j := len(reversedBoard[i]) - 1; j >= 0; j-- {
				oneDBoard = append(oneDBoard, reversedBoard[i][j])
			}
		}
	}

	queue := make([][2]int, 0)
	queue = append(queue, [2]int{0, 1})
	visited := make([]bool, len(oneDBoard))

	dieSides := 6
	for len(queue) > 0 {
		square, moves := queue[0][0], queue[0][1]
		queue = queue[1:]

		for steps := 1; steps <= dieSides; steps++ {
			moveTo := square + steps
			if oneDBoard[moveTo] != -1 {
				moveTo = oneDBoard[moveTo] - 1
			}

			if moveTo == len(oneDBoard)-1 {
				return moves
			}

			if !visited[moveTo] {
				queue = append(queue, [2]int{moveTo, moves + 1})
			}

			visited[moveTo] = true
		}
	}

	return -1
}
