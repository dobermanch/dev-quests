// https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array

package problems

import (
	"testing"
	"github.com/dobermanch/leetcode/core"
)

type SearchRange struct{}

func TestSearchRange(t *testing.T) {
	gen := core.TestSuite[SearchRange]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([]int {5,7,7,8,8,10}).Param(8).Result([]int{3,4})
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int {5,7,7,8,8,10}).Param(6).Result([]int{-1,-1})
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int {}).Param(0).Result([]int{-1,-1})
	}).Run(t)
}

func (SearchRange) Solution(nums []int, target int) []int {
	search := func(nums []int, target int, searchLeft bool) int {
		left := 0
		right := len(nums) - 1
		index := -1
		for (left <= right) {
			mid := (left + right) / 2
			if (nums[mid] < target) {
				left = mid + 1
			} else if (nums[mid] > target) {
				right = mid - 1
			} else {
				index = mid
				if (searchLeft) {
					right = mid - 1
				} else {
					left = mid + 1
				}
			}			 
		}

		return index
	}

	return []int {
		search(nums, target, true),
		search(nums, target, false),
	}
}
