// https://leetcode.com/problems/running-sum-of-1d-array/

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type RunningSum struct{}

func TestRunningSum(t *testing.T) {
	gen := core.TestSuite[RunningSum]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([]int{1,2,3,4}).Result([]int{1,3,6,10})
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{1,1,1,1,1}).Result([]int{1,2,3,4,5})
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{3,1,2,10,1}).Result([]int{3,4,6,16,17})
	}).Run(t)
}

func (RunningSum)Solution(nums []int) []int {
	length := len(nums)
	result := make([]int, length)
	result[0] = nums[0]

	for i := 1; i < length; i++ {
		result[i] = result[i-1] + nums[i]
	}

	return result
}