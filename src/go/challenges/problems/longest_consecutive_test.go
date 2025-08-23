// https://leetcode.com/problems/longest-consecutive-sequence/

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type LongestConsecutive struct{}

func TestLongestConsecutive(t *testing.T) {
	gen := core.TestSuite[LongestConsecutive]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([]int{100, 4, 200, 1, 3, 2}).Result(4)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{0, 3, 7, 2, 5, 8, 4, 6, 0, 1}).Result(9)
	}).Run(t)
}

func (LongestConsecutive) Solution(nums []int) int {
	set := map[int]struct{}{}
	max := 0

	for i := 0; i < len(nums); i++ {
		set[nums[i]] = struct{}{}
	}

	for key := range set {
		if _, ok := set[key-1]; ok {
			continue
		}

		count := 1
		for {
			if _, ok := set[key+count]; !ok {
				break
			}
			count++
		}

		if max < count {
			max = count
		}
	}

	return max
}
