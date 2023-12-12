// https://leetcode.com/problems/maximum-product-of-two-elements-in-an-array

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type MaxProduct2 struct{}

func TestMaxProduct2(t *testing.T) {
	gen := core.TestSuite[MaxProduct2]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([]int{3, 4, 5, 2}).Result(12)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{1, 5, 4, 5}).Result(16)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{3, 7}).Result(12)
	}).Run(t)
}

func (MaxProduct2) Solution(nums []int) int {
	num1 := 0
	num2 := 0
	for i := 0; i < len(nums); i++ {
		if nums[i] > num1 {
			num2 = num1
			num1 = nums[i]
		} else if nums[i] > num2 {
			num2 = nums[i]
		}
	}

	return (num1 - 1) * (num2 - 1)
}
