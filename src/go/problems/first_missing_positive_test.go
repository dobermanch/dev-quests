// https://leetcode.com/problems/first-missing-positive/

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type FirstMissingPositive struct{}

func TestFirstMissingPositive(t *testing.T) {
	gen := core.TestSuite[FirstMissingPositive]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([]int{1, 2, 0}).Result(3)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{3, 4, -1, 1}).Result(2)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{7, 8, 9, 11, 12}).Result(1)
	}).Run(t)
}

func (FirstMissingPositive) Solution(nums []int) int {
	length := len(nums)

	for i := 0; i < length; i++ {
		for nums[i] > 0 && nums[i] <= length && nums[i] != nums[nums[i]-1] {
			temp := nums[nums[i]-1]
			nums[nums[i]-1] = nums[i]
			nums[i] = temp
		}
	}

	for i := 0; i < length; i++ {
		if nums[i] != i+1 {
			return i + 1
		}
	}

	return length + 1
}
