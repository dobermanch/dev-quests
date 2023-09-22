// https://leetcode.com/problems/trapping-rain-water/

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type Trap struct{}

func TestTrap(t *testing.T) {
	gen := core.TestSuite[Trap]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([]int{0,1,0,2,1,0,1,3,2,1,2,1}).Result(6)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{4,2,0,3,2,5}).Result(9)
	}).Run(t)
}

func (Trap) Solution(height []int) int {
	left := 0
	right := len(height) - 1
	maxL, maxR := 0, 0
	trap := 0

	for left <= right {
		if maxL < maxR {
			if maxL-height[left] > 0 {
				trap += maxL - height[left]
			}
			maxL = max(maxL, height[left])
			left++
		} else {
			if maxR-height[right] > 0 {
				trap += maxR - height[right]
			}
			maxR = max(maxR, height[right])
			right--
		}
	}

	return trap
}

func max(left int, right int) int {
	if left > right {
		return left
	}

	return right
}

