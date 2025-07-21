// https://leetcode.com/problems/maximum-subarray/
package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type MaxSubArray struct{}

func TestMaxSubArray(t *testing.T) {
	gen := core.TestSuite[MaxSubArray]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([]int{-2, 1, -3, 4, -1, 2, 1, -5, 4}).Result(6)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{1}).Result(1)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{5, 4, -1, 7, 8}).Result(23)
	}).Run(t)
}

func (MaxSubArray) Solution(nums []int) int {
	sum := nums[0]
	max := nums[0]

	for i := 1; i < len(nums); i++ {
		sum = Max(sum+nums[i], nums[i])
		max = Max(max, sum)
	}

	return max
}

func Max(left int, right int) int {
	if left > right {
		return left
	}

	return right
}
