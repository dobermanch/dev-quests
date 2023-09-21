// https://leetcode.com/problems/maximum-subarray/
package problems

import "testing"

func TestMaxSubArray(t *testing.T) {
	result := MaxSubArray([]int{-2, 1, -3, 4, -1, 2, 1, -5, 4})
	t.Log(result)
}

func MaxSubArray(nums []int) int {
	sum := nums[0]
	max := nums[0]

	for i := 1; i < len(nums); i++ {
		sum = Max(sum+nums[i], nums[i])
		max = Max(max, sum)
	}

	return max
}

func Max(left int, right int) int {
	if left > right {
		return left
	}

	return right
}
