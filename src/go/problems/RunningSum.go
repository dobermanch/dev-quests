// https://leetcode.com/problems/running-sum-of-1d-array/

package problems

func RunningSum(nums []int) []int {
	length := len(nums)
	result := make([]int, length)
	result[0] = nums[0]

	for i := 1; i < length; i++ {
		result[i] = result[i-1] + nums[i]
	}

	return result
}
