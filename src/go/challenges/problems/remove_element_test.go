// https://leetcode.com/problems/remove-element

package problems

import (
	"testing"
	"github.com/dobermanch/leetcode/core"
)

type RemoveElement struct{}

func TestRemoveElement(t *testing.T) {
	gen := core.TestSuite[RemoveElement]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([]int{3,2,2,3}).Param(3).Result(2)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{0,1,2,2,3,0,4,2}).Param(2).Result(5)
	}).Run(t)
}

func (RemoveElement) Solution(nums []int, val int) int {
    left := 0
    for right := 0; right < len(nums); right++ {
        if nums[right] != val {
            nums[left] = nums[right]
            left++
        }
    }

    return left
}