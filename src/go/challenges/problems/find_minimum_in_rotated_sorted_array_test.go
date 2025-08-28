// https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type FindMin struct{}

func TestFindMin(t *testing.T) {
	gen := core.TestSuite[FindMin]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([]int{3, 4, 5, 1, 2}).Result(1)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{4, 5, 6, 7, 0, 1, 2}).Result(0)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{11, 13, 15, 17}).Result(11)
	}).Run(t)
}

func (FindMin) Solution(nums []int) int {
	left := 0
	right := len(nums) - 1

	for left < right {
		mid := (left + right) / 2
		if nums[right] < nums[mid] {
			left = mid + 1
		} else {
			right = mid
		}
	}

	return nums[left]
}
