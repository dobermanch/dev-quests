// https://leetcode.com/problems/n-queens

package problems

import (
	"testing"
	"github.com/dobermanch/leetcode/core"
)

type SolveNQueens struct{}

func TestSolveNQueens(t *testing.T) {
	gen := core.TestSuite[SolveNQueens]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param(4).Result([][]string{{".Q..","...Q","Q...","..Q."},{"..Q.","Q...","...Q",".Q.."}})
	}).Run(t)
}

func (SolveNQueens) Solution(n int) [][]string {
    result := [][]string{}
	board := make([][]rune, n)

	for row := 0; row < n; row++ {
		for col := 0; col < n; col++ {
			board[row] = append(board[row], '.')
		}
	}

    var placeQueen func(int)
	var canPlace func(int, int) bool

	placeQueen = func(row int) {
		if row >= n {
			result = append(result, []string{})
			for r := 0; r < n; r++ {
				result[len(result) - 1] = append(result[len(result)-1], string(board[r]))
			}
			
			return
		}

		for col := 0; col < n; col++ {
			if canPlace(row, col) {
				board[row][col] = 'Q'
				placeQueen(row + 1)
				board[row][col] = '.'
			}
		}
	}


	canPlace = func(row int, col int) bool {
		for r := row; r >= 0; r-- {
            if board[r][col] == 'Q' {
                return false
            }
        }

		r := row
		c := col
		for r >= 0 && c >= 0 {
			if board[r][c] == 'Q' {
				return false
			}
			r--
			c--
		}

		r = row
		c = col
		for r >= 0 && c < n {
			if board[r][c] == 'Q' {
				return false
			}
			r--
			c++
		}

		return true
	}

	placeQueen(0)
	
	return result
}
