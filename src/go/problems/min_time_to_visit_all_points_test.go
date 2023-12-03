// https://leetcode.com/problems/minimum-time-visiting-all-points

package problems

import (
	"math"
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type MinTimeToVisitAllPoints struct{}

func TestMinTimeToVisitAllPoints(t *testing.T) {
	gen := core.TestSuite[MinTimeToVisitAllPoints]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param(10).Param(13).Result(23)
	}).Add(func(tc *core.TestCase) {
		tc.Param(-10).Param(12).Result(2)
	}).Run(t)
}

func (MinTimeToVisitAllPoints) Solution(points [][]int) int {
	result := 0.0
	for i := 1; i < len(points); i++ {
		result += math.Max(
			math.Abs(float64(points[i-1][0]-points[i][0])),
			math.Abs(float64(points[i-1][1]-points[i][1])))
	}

	return int(result)
}
