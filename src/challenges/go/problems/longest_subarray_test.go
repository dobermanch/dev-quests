// https://leetcode.com/problems/longest-subarray-of-1s-after-deleting-one-element

package problems

import (
	"testing"
	"github.com/dobermanch/leetcode/core"
)

type LongestSubarray struct{}

func TestLongestSubarray(t *testing.T) {
	gen := core.TestSuite[LongestSubarray]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([]int{1,1,0,1}).Result(3)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{0,1,1,1,0,1,1,0,1}).Result(5)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{1,1,1}).Result(2)
	}).Run(t)
}

func (LongestSubarray) Solution(nums []int) int {
    count := 0
    left := 0
    for right := 0; right < len(nums); right++ {
        if nums[right] == 0 {
            count++
        }

        if count > 1 {
            if nums[left] == 0{
                count--
            }

            left++
        }
    }

    return len(nums) - left - 1
}