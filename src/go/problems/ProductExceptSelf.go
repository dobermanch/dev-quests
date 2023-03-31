// https://leetcode.com/problems/product-of-array-except-self

package problems

func ProductExceptSelf(nums []int) []int {
	length := len(nums)
	result := make([]int, length)
	result[0] = nums[0]

	for i := 0; i < length; i++ {
		result[i+1] = result[i] * nums[i]
	}

	product := nums[length-1]
	for i := length - 1; i >= 0; i-- {
		result[i] *= product
		product *= nums[i]
	}

	return result
}
