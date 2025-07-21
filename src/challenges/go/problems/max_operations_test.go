// https://leetcode.com/problems/max-number-of-k-sum-pairs/

package problems

import (
	"sort"
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type MaxOperations struct{}

func TestMaxOperations(t *testing.T) {
	gen := core.TestSuite[MaxOperations]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([]int{1,2,3,4}).Param(5).Result(2)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{3,1,3,4,3}).Param(6).Result(1)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{4,4,1,3,1,3,2,2,5,5,1,5,2,1,2,3,5,4}).Param(2).Result(2)
	}).Run(t)
}

func (MaxOperations) Solution(nums []int, k int) int {
	result := 0

	sort.Ints(nums)

	left := 0
	right := len(nums) - 1
	for left < right {
		sum := nums[left] + nums[right]
		if sum == k {
			left++
			right--
			result++
		} else if sum > k {
			right--
		} else {
			left++
		}
	}

	return result
}
