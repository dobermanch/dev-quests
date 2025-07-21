// https://leetcode.com/problems/remove-duplicates-from-sorted-array-ii

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type RemoveDuplicates2 struct{}

func TestRemoveDuplicates2(t *testing.T) {
	gen := core.TestSuite[RemoveDuplicates2]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([]int{1, 1, 1, 2, 2, 3}).Result(5)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{0, 0, 1, 1, 1, 1, 2, 3, 3}).Result(7)
	}).Run(t)
}

func (RemoveDuplicates2) Solution(nums []int) int {
	left := 1
	count := 1
	for right := 1; right < len(nums); right++ {
		if nums[right] == nums[right-1] {
			count++
		} else {
			count = 1
		}

		if count <= 2 {
			nums[left] = nums[right]
			left++
		}
	}

	return left
}
