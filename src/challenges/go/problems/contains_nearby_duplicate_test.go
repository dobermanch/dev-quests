// https://leetcode.com/problems/contains-duplicate-ii

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type ContainsNearbyDuplicate struct{}

func TestContainsNearbyDuplicate(t *testing.T) {
	gen := core.TestSuite[ContainsNearbyDuplicate]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([]int{1, 2, 3, 1}).Param(3).Result(true)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{1, 0, 1, 1}).Param(1).Result(true)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{1, 2, 3, 1, 2, 3}).Param(2).Result(false)
	}).Run(t)
}

func (ContainsNearbyDuplicate) Solution(nums []int, k int) bool {
	set := map[int]int{}

	for i, num := range nums {
		if _, ok := set[num]; ok {
			if i-set[num] <= k {
				return true
			}
		}

		set[nums[i]] = i
	}

	return false
}
