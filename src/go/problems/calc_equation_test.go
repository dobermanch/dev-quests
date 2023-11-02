// https://leetcode.com/problems/evaluate-division/

package problems

import (
	"testing"
	"github.com/dobermanch/leetcode/core"
)

type CalcEquation struct{}

func TestCalcEquation(t *testing.T) {
	gen := core.TestSuite[CalcEquation]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([][]string{{"a","b"},{"b","c"}}).Param([]float64{2.0,3.0}).Param([][]string{{"a","c"},{"b","a"},{"a","e"},{"a","a"},{"x","x"}}).Result([]float64{6.00000,0.50000,-1.00000,1.00000,-1.00000})
	}).Run(t)
}

func (CalcEquation) Solution(equations [][]string, values []float64, queries [][]string) []float64 {
    nodes := map[string]map[string]float64{}

    var dfs func(string, string, map[string]bool) float64
	dfs = func(current string, target string, visited map[string]bool) float64 {
		if _, ok := nodes[current]; !ok {
			return -1;
		}

		if current == target {
			return 1
		}

        visited[current] = true
		for node, weight := range nodes[current] {
			if visited[node] {
				continue
			}

			result := dfs(node, target, visited)
			if result != -1 {
				return result * weight
			}
		}

		return -1
	}

	for i := 0; i < len(equations); i++ {
        if _, ok := nodes[equations[i][0]]; !ok {
			nodes[equations[i][0]] = make(map[string]float64)
		}
		nodes[equations[i][0]][equations[i][1]] = values[i]

		if _, ok := nodes[equations[i][1]]; !ok {
			nodes[equations[i][1]] = make(map[string]float64)
		}        
		nodes[equations[i][1]][equations[i][0]] = 1 / values[i]
	}

	result := make([]float64, len(queries))
	for i := 0; i < len(queries); i++ {
		result[i] = dfs(queries[i][0], queries[i][1], map[string]bool{})
	}
	
	return result
}
