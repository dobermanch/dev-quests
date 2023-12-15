// https://leetcode.com/problems/destination-city

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type DestCity struct{}

func TestDestCity(t *testing.T) {
	gen := core.TestSuite[DestCity]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([][]string{{"London", "New York"}, {"New York", "Lima"}, {"Lima", "Sao Paulo"}}).Result("Sao Paulo")
	}).Add(func(tc *core.TestCase) {
		tc.Param([][]string{{"B", "C"}, {"D", "B"}, {"C", "A"}}).Result("A")
	}).Add(func(tc *core.TestCase) {
		tc.Param([][]string{{"A", "Z"}}).Result("Z")
	}).Run(t)
}

func (DestCity) Solution(paths [][]string) string {
	from := map[string]bool{}
	for i := 0; i < len(paths); i++ {
		from[paths[i][0]] = true
	}

	for _, path := range paths {
		if !from[path[1]] {
			return path[1]
		}
	}

	return ""
}
