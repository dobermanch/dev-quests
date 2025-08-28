// https://leetcode.com/problems/container-with-most-water/

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type MaxArea struct{}

func TestMaxArea(t *testing.T) {
	gen := core.TestSuite[MaxArea]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([]int{1, 8, 6, 2, 5, 4, 8, 3, 7}).Result(49)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{1, 1}).Result(1)
	}).Run(t)
}

func (MaxArea) Solution(height []int) int {
	max := 0
	left := 0
	right := len(height) - 1

	for left < right {
		maxHeight := min(height[left], height[right])
		width := right - left
		capacity := width * maxHeight

		if capacity > max {
			max = capacity
		}

		if height[left] < height[right] {
			left++
		} else {
			right--
		}
	}

	return max
}

func min(left int, right int) int {
	if left < right {
		return left
	}

	return right
}
