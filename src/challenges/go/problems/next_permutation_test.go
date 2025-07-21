// https://leetcode.com/problems/next-permutation/

package problems

import (
	"testing"
	"github.com/dobermanch/leetcode/core"
)

type NextPermutation struct{}

func TestNextPermutation(t *testing.T) {
	gen := core.TestSuite[NextPermutation]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([]int{1,2,3}).Result([]int{1,3,2})
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{3,2,1}).Result([]int{1,2,3})
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{1,1,5}).Result([]int{1,5,1})
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{1,3,2}).Result([]int{2,1,3})
	}).Run(t)
}

func (NextPermutation) Solution(nums []int) []int {
	right := len(nums) - 1
	left := right - 1
	found := false

	for (left >= 0) {
		if (!found && nums[left] < nums[right]) {
			found = true
			right = len(nums) - 1
		} else if (!found) {
			left--
			right--
		} else {
				if (nums[left] < nums[right]) {
				nums[left], nums[right] = nums[right], nums[left]
				break
			}
			right--
		}
	}

	for i, j := left + 1, len(nums) - 1; i < j; i, j = i + 1, j - 1 {
		nums[i], nums[j] = nums[j], nums[i]
	}

	return nums
}
