// https://leetcode.com/problems/two-sum/

package problems

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
