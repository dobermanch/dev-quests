// https://leetcode.com/problems/product-of-array-except-self
package problems

import "testing"

func TestProductExceptSelf(t *testing.T) {
	result := ProductExceptSelf([]int{1, 2, 3, 4})
	t.Log(result)
}

func ProductExceptSelf(nums []int) []int {
	length := len(nums)
	result := make([]int, length)
	result[0] = 1

	for i := 0; i < length-1; i++ {
		result[i+1] = result[i] * nums[i]
	}

	product := nums[length-1]
	for i := length - 2; i >= 0; i-- {
		result[i] *= product
		product *= nums[i]
	}

	return result
}
