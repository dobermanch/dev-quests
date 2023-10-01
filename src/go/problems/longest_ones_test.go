// https://leetcode.com/problems/max-consecutive-ones-iii/

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type LongestOnes struct{}

func TestLongestOnes(t *testing.T) {
	gen := core.TestSuite[LongestOnes]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([]int{1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0}).Param(2).Result(6)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1}).Param(3).Result(10)
	}).Run(t)
}

func (LongestOnes) Solution(nums []int, k int) int {
	result := 0
	left := 0
	right := 0

	for right < len(nums) {
		if nums[right] == 1 {
			right++
		} else if k > 0 {
			k--
			right++
		} else {
			if nums[left] == 0 {
				k++
			}
			left++
		}

		count := right - left
		if result < count {
			result = count
		}
	}

	return result
}
