// https://leetcode.com/problems/find-peak-element

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type FindPeakElement struct{}

func TestFindPeakElement(t *testing.T) {
	gen := core.TestSuite[FindPeakElement]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([]int{1,2,3,1}).Result(2)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{1,2,1,3,5,6,4}).Result(5)
	}).Run(t)
}

func (FindPeakElement) Solution(nums []int) int {
    length := len(nums) - 1
    left := 0
    right := length
    for left <= right {
        mid := (left + right) / 2
        if mid < length && nums[mid] < nums[mid + 1] {
            left = mid + 1
        } else if mid > 0 && nums[mid - 1] > nums[mid] {
            right = mid - 1
        } else {
            return mid
        }
    }

    return 0
}
