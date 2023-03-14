// https://leetcode.com/problems/first-missing-positive/

package problems

import (
	"testing"
)

func TestFirstMissingPositive(t *testing.T) {
	result := FirstMissingPositive([]int{3,4,-1,1})
	t.Log(result)
}

func FirstMissingPositive(nums []int) []int {
	length := len(nums)

	for i := 0; i < length; i++ {
		for nums[i] > 0 && nums[i] <= length && nums[i] != nums[nums[i] - 1] {
			temp := nums[nums[i] - 1]
			nums[nums[i] - 1] = nums[i]
			nums[i] = temp
		}
	}

	for i,v := range nums {
		if v != i + 1 {
			return i + 1
		}
	}

	return length + 1
}
