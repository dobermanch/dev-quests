// https://leetcode.com/problems/find-pivot-index/
package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type PivotIndex struct{}

func TestPivotIndex(t *testing.T) {
	gen := core.TestSuite[PivotIndex]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([]int{1, 7, 3, 6, 5, 6}).Result(3)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{1, 2, 3}).Result(-1)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{2, 1, -1}).Result(0)
	}).Run(t)
}

func (PivotIndex) Solution(nums []int) int {
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
