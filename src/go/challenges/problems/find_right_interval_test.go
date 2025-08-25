// https://leetcode.com/problems/find-right-interval

package problems

import (
	"sort"
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type FindRightInterval struct{}

func TestFindRightInterval(t *testing.T) {
	gen := core.TestSuite[FindRightInterval]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([][]int{{1, 12}, {2, 9}, {3, 10}, {13, 14}, {15, 16}, {16, 17}}).Result([]int{3, 3, 3, 4, 5, -1})
	}).Add(func(tc *core.TestCase) {
		tc.Param([][]int{{4, 4}}).Result([]int{0})
	}).Run(t)
}

func (FindRightInterval) Solution(intervals [][]int) []int {
	length := len(intervals)
	result := make([]int, length)

	sorted_intervals := [][]int{}

	for i := range intervals {
		sorted_intervals = append(sorted_intervals, []int{intervals[i][0], i})
	}

	sort.Slice(sorted_intervals, func(i, j int) bool {
		return sorted_intervals[i][0] < sorted_intervals[j][0]
	})

	for index := range intervals {
		left := 0
		right := length - 1

		target := intervals[index][1]
		for left <= right {
			mid := (left + right) / 2

			if sorted_intervals[mid][0] < target {
				left = mid + 1
			} else {
				right = mid - 1
			}
		}

		if left >= 0 && left < length {
			result[index] = sorted_intervals[left][1]
		} else {
			result[index] = -1
		}
	}

	return result
}
