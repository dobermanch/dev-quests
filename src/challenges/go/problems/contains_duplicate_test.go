//https://leetcode.com/problems/contains-duplicate/

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type ContainsDuplicate struct{}

func TestContainsDuplicate(t *testing.T) {
	gen := core.TestSuite[ContainsDuplicate]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([]int{1,2,3,1}).Result(true)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{1,2,3,4}).Result(false)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{1,1,1,3,3,4,3,2,4,2}).Result(true)
	}).Run(t)
}

func (ContainsDuplicate) Solution(nums []int) bool {
	set := make(map[int]struct{})

	for i := 0; i < len(nums); i++ {
		if _, ok := set[nums[i]]; ok {
			return true
		}

		set[nums[i]] = struct{}{}
	}

	return false
}
