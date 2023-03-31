// https://leetcode.com/problems/running-sum-of-1d-array/

package problems

func PivotIndex(nums []int) int {
	var leftSum int
	var rightSum int
	var index int

	for i := 1; i < len(nums); i++ {
		rightSum += nums[i]
	}

	for leftSum != rightSum && index < len(nums)-1 {
		leftSum += nums[index]
		rightSum += nums[index+1]
		index++
	}

	if leftSum != rightSum {
		return -1
	}

	return index
}
