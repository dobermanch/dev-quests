// https://leetcode.com/problems/jump-game

package problems

import (
	"testing"
	"github.com/dobermanch/leetcode/core"
)

type CanJump struct{}

func TestCanJump(t *testing.T) {
	gen := core.TestSuite[CanJump]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([]int{2,3,1,1,4}).Result(true)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{3,2,1,0,4}).Result(false)
	}).Run(t)
}

func (CanJump) Solution(nums []int) bool {
    jumpTo := len(nums) - 1
    for i := jumpTo - 1; i >= 0; i-- {
        if i + nums[i] >= jumpTo {
            jumpTo = i
        }
    }

    return jumpTo == 0
}
