// https://leetcode.com/problems/product-of-array-except-self
package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type ProductExceptSelf struct{}

func TestProductExceptSelf(t *testing.T) {
	gen := core.TestSuite[ProductExceptSelf]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([]int{1, 2, 3, 4}).Result([]int{24, 12, 8, 6})
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{-1, 1, 0, -3, 3}).Result([]int{0, 0, 9, 0, 0})
	}).Run(t)
}

func (ProductExceptSelf) Solution(nums []int) []int {
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
