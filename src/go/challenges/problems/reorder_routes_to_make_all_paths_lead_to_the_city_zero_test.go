// https://leetcode.com/problems/reorder-routes-to-make-all-paths-lead-to-the-city-zero

package problems

import (
	"testing"
	"github.com/dobermanch/leetcode/core"
)

type MinReorder struct{}

func TestMinReorder(t *testing.T) {
	gen := core.TestSuite[MinReorder]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param(10).Param(13).Result(23)
	}).Add(func(tc *core.TestCase) {
		tc.Param(-10).Param(12).Result(2)
	}).Run(t)
}

func (MinReorder) Solution(n int, connections [][]int) int {	
	neighbors := map[int][][]int{}
	for i := 0; i < n; i++ {
		neighbors[i] = [][]int{}
	}

	for i := 0; i < len(connections); i++ {
		neighbors[connections[i][0]] = append(neighbors[connections[i][0]], []int{connections[i][1], 1})
		neighbors[connections[i][1]] = append(neighbors[connections[i][1]], []int{connections[i][0], 0})
	}

	visited := make([]bool, n)
	
	var dfs func(city int) int
	dfs = func(current int) int {
		result := 0
		visited[current] = true

		for i := 0; i < len(neighbors[current]); i++ {
			neighbor := neighbors[current][i]
			if visited[neighbor[0]] {
				continue
			}

			if neighbor[1] == 1 {
				result++
			}

			result += dfs(neighbor[0])
		}
		return result
	}

	return dfs(0)
}
