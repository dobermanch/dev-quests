// https://leetcode.com/problems/path-crossing/

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type IsPathCrossing struct{}

func TestIsPathCrossing(t *testing.T) {
	gen := core.TestSuite[IsPathCrossing]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param("NES").Result(false)
	}).Add(func(tc *core.TestCase) {
		tc.Param("NESWW").Result(true)
	}).Run(t)
}

func (IsPathCrossing) Solution(path string) bool {
	point := [2]int{0, 0}

	visited := make(map[[2]int]bool)
	visited[point] = true

	for _, direction := range path {
		switch direction {
		case 'N':
			point[1]++
		case 'S':
			point[1]--
		case 'E':
			point[0]++
		case 'W':
			point[0]--
		}

		if visited[point] {
			return true
		}

		visited[point] = true
	}

	return false
}
