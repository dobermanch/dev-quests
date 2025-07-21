// https://leetcode.com/problems/widest-vertical-area-between-two-points-containing-no-points

package problems

import (
	"sort"
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type MaxWidthOfVerticalArea struct{}

func TestMaxWidthOfVerticalArea(t *testing.T) {
	gen := core.TestSuite[MaxWidthOfVerticalArea]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([][]int{{8, 7}, {9, 9}, {7, 4}, {9, 7}}).Result(3)
	}).Add(func(tc *core.TestCase) {
		tc.Param([][]int{{3, 1}, {9, 0}, {1, 0}, {1, 4}, {5, 3}, {8, 8}}).Result(3)
	}).Run(t)
}

func (MaxWidthOfVerticalArea) Solution(points [][]int) int {
	sort.Slice(points, func(i, j int) bool {
		return points[i][0] < points[j][0]
	})

	maxDiff := 0
	for i := 1; i < len(points); i++ {
		diff := points[i][0] - points[i-1][0]
		if diff > maxDiff {
			maxDiff = diff
		}
	}

	return maxDiff
}
