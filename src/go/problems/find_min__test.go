// https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/

package problems

import (
	"testing"
)

func TestFindMin(t *testing.T) {
	result := FindMin([]int{4, 5, 6, 7, 0, 1, 2})
	t.Log(result)
}

func FindMin(nums []int) int {
	left := 0
	right := len(nums) - 1

	for left < right {
		mid := (left + right) / 2
		if nums[right] < nums[mid] {
			left = mid + 1
		} else {
			right = mid
		}
	}

	return nums[left]
}
