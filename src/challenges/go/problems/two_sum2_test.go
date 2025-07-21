// https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type TwoSum2 struct{}

func TestTwoSum2(t *testing.T) {
	gen := core.TestSuite[TwoSum2]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([]int{2, 7, 11, 15}).Param(9).Result([]int{1, 2})
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{2, 3, 4}).Param(6).Result([]int{1, 3})
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{-1, 0}).Param(-1).Result([]int{1, 2})
	}).Run(t)
}

func (TwoSum2) Solution(numbers []int, target int) []int {
	start := 0
	end := len(numbers) - 1

	for start < end {
		sum := numbers[start] + numbers[end]

		if sum == target {
			break
		}

		if sum > target {
			end--
		} else {
			start++
		}
	}

	return []int{start + 1, end + 1}
}
