// https://leetcode.com/problems/remove-duplicates-from-sorted-array

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type RemoveDuplicates struct{}

func TestRemoveDuplicates(t *testing.T) {
	gen := core.TestSuite[RemoveDuplicates]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([]int{1, 1, 2}).Result(2)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{0, 0, 1, 1, 1, 2, 2, 3, 3, 4}).Result(5)
	}).Run(t)
}

func (RemoveDuplicates) Solution(nums []int) int {
	left := 1
	for right := 1; right < len(nums); right++ {
		if nums[right] != nums[right-1] {
			nums[left] = nums[right]
			left++
		}
	}

	return left
}
