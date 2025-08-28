// https://leetcode.com/problems/jump-game-ii/

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type Jump struct{}

func TestJump(t *testing.T) {
	gen := core.TestSuite[Jump]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([]int{2,3,1,1,4}).Result(2)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{2,3,0,1,4}).Result(2)
	}).Run(t)
}

func (Jump) Solution(nums []int) int {
    result := 0
	length := len(nums) - 1
	left := 0
	right := 0
	max := 0

	for (right < length) {
		if (left <= right) {
			if left + nums[left] > max {
				max = left + nums[left]
			}

			left++
		} else {
			right = max
			result++
		}
	}

	return result
}
