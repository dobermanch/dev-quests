// https://leetcode.com/problems/sort-matrix-by-diagonals

package problems

import (
	"sort"
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type SortMatrixByDiagonals struct{}

func TestSortMatrixByDiagonals(t *testing.T) {
	gen := core.TestSuite[SortMatrixByDiagonals]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([][]int{{1, 7, 3, 5}, {9, 8, 2, 2}, {4, 5, 6, 8}, {4, 2, 8, 7}}).Result([][]int{{8, 2, 2, 5}, {9, 7, 7, 3}, {4, 8, 6, 8}, {4, 2, 5, 1}})
	}).Run(t)
}

func (SortMatrixByDiagonals) Solution(grid [][]int) [][]int {
	n := len(grid)

	diagonals := [][]int{}

	for i := 0; i < 2*n-1; i++ {
		diagonals = append(diagonals, []int{})
	}

	for row := 0; row < n; row++ {
		for col := 0; col < n; col++ {
			diagonal := n + col - row - 1
			diagonals[diagonal] = append(diagonals[diagonal], grid[row][col])
		}
	}

	for i := 0; i < len(diagonals); i++ {
		if i < n {
			sort.Sort(sort.Reverse(sort.IntSlice(diagonals[i])))
		} else {
			sort.Ints(diagonals[i])
		}

		length := len(diagonals[i])
		for j := 0; j < length; j++ {
			row := n - length + j
			col := j
			if i >= n {
				row = j
				col = n - length + j
			}

			grid[row][col] = diagonals[i][j]
		}
	}

	return grid
}
