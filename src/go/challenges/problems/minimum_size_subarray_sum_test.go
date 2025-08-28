// https://leetcode.com/problems/minimum-size-subarray-sum

package problems

import (
	"math"
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type MinSubArrayLen struct{}

func TestMinSubArrayLen(t *testing.T) {
	gen := core.TestSuite[MinSubArrayLen]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param(7).Param([]int{2, 3, 1, 2, 4, 3}).Result(2)
	}).Add(func(tc *core.TestCase) {
		tc.Param(4).Param([]int{1, 4, 4}).Result(1)
	}).Add(func(tc *core.TestCase) {
		tc.Param(11).Param([]int{1, 1, 1, 1, 1, 1, 1, 1}).Result(0)
	}).Run(t)
}

func (MinSubArrayLen) Solution(target int, nums []int) int {
	result := math.MaxInt
	left := 0
	right := 0
	sum := 0
	for right < len(nums) || sum >= target {
		if sum >= target {
			diff := right - left
			if result > diff {
				result = diff
			}
			sum -= nums[left]
			left++
		} else {
			sum += nums[right]
			right++
		}
	}

	if result == math.MaxInt {
		return 0
	}

	return result
}
