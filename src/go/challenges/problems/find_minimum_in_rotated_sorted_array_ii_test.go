// https://leetcode.com/problems/find-minimum-in-rotated-sorted-array-ii

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type FindMinimumInRotatedSortedArrayIi struct{}

func TestFindMinimumInRotatedSortedArrayIi(t *testing.T) {
	gen := core.TestSuite[FindMinimumInRotatedSortedArrayIi]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([]int{10, 1, 10, 10, 10}).Result(1)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{3, 3, 3, 5, 1, 3, 3}).Result(1)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{3, 3, 1, 3}).Result(1)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{1, 3, 3}).Result(1)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{1, 3, 5}).Result(1)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{1, 1, 1, 1, 1}).Result(1)
	}).Run(t)
}

func (FindMinimumInRotatedSortedArrayIi) Solution(nums []int) int {
	left := 0
	right := len(nums) - 1

	for left < right {
		mid := (left + right) / 2
		if nums[mid] > nums[right] {
			left = mid + 1
		} else if nums[left] == nums[mid] && nums[mid] == nums[right] {
			right--
		} else {
			right = mid
		}
	}

	return nums[left]
}
