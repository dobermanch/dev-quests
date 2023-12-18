// https://leetcode.com/problems/maximum-product-difference-between-two-pairs

package problems

import (
	"math"
	"sort"
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type MaxProductDifference struct{}

func TestMaxProductDifference(t *testing.T) {
	gen := core.TestSuite[MaxProductDifference]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([]int{1, 6, 7, 5, 2, 4, 10, 6, 4}).Result(68)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{4, 2, 5, 9, 7, 4, 8}).Result(64)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{5, 6, 2, 7, 4}).Result(34)
	}).Run(t)
}

func (MaxProductDifference) Solution1(nums []int) int {
	min1 := math.MaxInt
	min2 := math.MaxInt
	max1 := math.MinInt
	max2 := math.MinInt

	for i := 0; i < len(nums); i++ {
		if nums[i] > max1 {
			max2 = max1
			max1 = nums[i]
		} else if nums[i] > max2 {
			max2 = nums[i]
		}

		if nums[i] < min1 {
			min2 = min1
			min1 = nums[i]
		} else if nums[i] < min2 {
			min2 = nums[i]
		}
	}

	return max1*max2 - min1*min2
}

func (MaxProductDifference) Solution2(nums []int) int {
	sort.Ints(nums)
	length := len(nums)
	return nums[length-2]*nums[length-1] - nums[0]*nums[1]
}
