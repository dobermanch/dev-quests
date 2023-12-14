// https://leetcode.com/problems/running-sum-of-1d-array/

package problems

import (
	"testing"
	"github.com/dobermanch/leetcode/core"
)

type OnesMinusZeros struct{}

func TestOnesMinusZeros(t *testing.T) {
	gen := core.TestSuite[OnesMinusZeros]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([][]int{{0,1,1},{1,0,1},{0,0,1}}).Result([][]int{{0,0,4},{0,0,4},{-2,-2,2}})
	}).Add(func(tc *core.TestCase) {
		tc.Param([][]int{{1,1,1},{1,1,1}}).Result([][]int{{5,5,5},{5,5,5}})
	}).Run(t)
}

func (OnesMinusZeros) Solution(grid [][]int) [][]int {
    rows := len(grid)
    cols := len(grid[0])    
    rowMap := make([]int, rows)
    colMap := make([]int, cols)

    for row := 0; row < rows; row++ {
        for col := 0; col < cols; col++ {
            if grid[row][col] == 1 {
                rowMap[row]++
                colMap[col]++
            }
        }
    }

    result := make([][]int, rows)
    for row := 0; row < rows; row++ {
        result[row] = make([]int, cols)
        for col := 0; col < cols; col++ {
            result[row][col] = rowMap[row] + colMap[col] - (rows - rowMap[row]) - (cols - colMap[col])
        }
    }

    return result
}
