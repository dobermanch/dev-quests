// https://leetcode.com/problems/3sum/

package problems

import (
	"sort"
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type ThreeSum struct{}

func TestThreeSum(t *testing.T) {
	gen := core.TestSuite[ThreeSum]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([]int{1,0,1,2,-1,-4}).Result([][]int{{-1,-1,2},{-1,0,1}})
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{0,1,1}).Result([][]int{})
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{0,0,0}).Result([][]int{{0,0,0}})
	}).Run(t)
}

func (ThreeSum) Solution(nums []int) [][]int {
	sort.Ints(nums)

	result := [][]int{}

	for i := 0; i < len(nums)-2; i++ {
		if i > 0 && nums[i-1] == nums[i] {
			continue
		}
		if nums[i] > 0 {
			break
		}

		left := i + 1
		right := len(nums) - 1
		for left < right {
			if left > i+1 && nums[left-1] == nums[left] {
				left++
				continue
			}

			sum := nums[i] + nums[left] + nums[right]
			if sum == 0 {
				result = append(result, []int{nums[i], nums[left], nums[right]})
			}

			if sum <= 0 {
				left++
			} else {
				right--
			}
		}
	}

	return result
}
