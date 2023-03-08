// https://leetcode.com/problems/trapping-rain-water/

package problems

import (
	"testing"
)

func TestTrap(t *testing.T) {
	result := Trap([]int{0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1})
	t.Log(result)
}

func Trap(height []int) int {
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
