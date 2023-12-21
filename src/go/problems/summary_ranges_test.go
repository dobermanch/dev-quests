// https://leetcode.com/problems/summary-ranges

package problems

import (
	"fmt"
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type SummaryRanges struct{}

func TestSummaryRanges(t *testing.T) {
	gen := core.TestSuite[SummaryRanges]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([]int{0, 1, 2, 4, 5, 7}).Result([]string{"0->2", "4->5", "7"})
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{0, 2, 3, 4, 6, 8, 9}).Result([]string{"0", "2->4", "6", "8->9"})
	}).Run(t)
}

func (SummaryRanges) Solution(nums []int) []string {
	result := []string{}
	startAt := 0
	length := len(nums)
	for i := 0; i < length; i++ {
		if i == length-1 || nums[i]+1 < nums[i+1] {
			if i == startAt {
				result = append(result, fmt.Sprintf("%d", nums[startAt]))
			} else {
				result = append(result, fmt.Sprintf("%d->%d", nums[startAt], nums[i]))
			}

			startAt = i + 1
		}
	}

	return result
}
