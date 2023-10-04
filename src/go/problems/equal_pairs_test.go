// https://leetcode.com/problems/equal-row-and-column-pairs/

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type EqualPairs struct{}

func TestEqualPairs(t *testing.T) {
	gen := core.TestSuite[EqualPairs]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([][]int{{3, 2, 1}, {1, 7, 6}, {2, 7, 7}}).Result(1)
	}).Add(func(tc *core.TestCase) {
		tc.Param([][]int{{3, 1, 2, 2}, {1, 4, 4, 5}, {2, 4, 2, 2}, {2, 4, 2, 2}}).Result(2)
	}).Run(t)
}

func (EqualPairs) Solution(grid [][]int) int {
	colMap := map[int][]int{}
	for c := 0; c < len(grid); c++ {
		colMap[grid[0][c]] = append(colMap[grid[0][c]], c)
	}

	result := 0
	for r := 0; r < len(grid); r++ {
		if _, ok := colMap[grid[r][0]]; !ok {
			continue
		}

		for _, col := range colMap[grid[r][0]] {
			matched := true

			for i := 1; i < len(grid); i++ {
				if grid[i][col] != grid[r][i] {
					matched = false
					break
				}
			}

			if matched {
				result++
			}
		}
	}

	return result
}
