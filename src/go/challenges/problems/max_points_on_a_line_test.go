// https://leetcode.com/problems/max-points-on-a-line

package problems

import (
	"github.com/dobermanch/leetcode/core"
	"math"
	"testing"
)

type MaxPointsOnALine struct{}

func TestMaxPointsOnALine(t *testing.T) {
	gen := core.TestSuite[MaxPointsOnALine]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([][]int{{1, 1}, {3, 2}, {5, 3}, {4, 1}, {2, 3}, {1, 4}}).Result(4)
	}).Add(func(tc *core.TestCase) {
		tc.Param([][]int{{1, 1}, {2, 2}, {3, 3}}).Result(2)
	}).Run(t)
}

func (MaxPointsOnALine) Solution(points [][]int) int {
	if len(points) <= 2 {
		return len(points)
	}

	maxPoints := 1
	for i := 0; i < len(points); i++ {
		slopes := map[float64]int{}
		for j := i + 1; j < len(points); j++ {
			x1, y1 := points[i][0], points[i][1]
			x2, y2 := points[j][0], points[j][1]

			slope := float64(math.MaxInt32 - 1)
			if x1-x2 != 0 {
				slope = float64(y1-y2) / float64(x1-x2)
			}

			if _, ok := slopes[slope]; ok {
				slopes[slope] += 1
			} else {
				slopes[slope] = 1
			}

			if slopes[slope] > maxPoints {
				maxPoints = slopes[slope]
			}
		}
	}

	return maxPoints + 1
}
