// https://leetcode.com/problems/minimum-number-of-operations-to-make-array-empty

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type MinOperations1 struct{}

func TestMinOperations1(t *testing.T) {
	gen := core.TestSuite[MinOperations1]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([]int{2, 3, 3, 2, 2, 4, 2, 3, 4}).Result(4)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{2, 1, 2, 2, 3, 3}).Result(-1)
	}).Run(t)
}

func (MinOperations1) Solution(nums []int) int {
	set := map[int]int{}
	for i := 0; i < len(nums); i++ {
		set[nums[i]]++
	}

	result := 0
	for _, value := range set {
		if value == 1 {
			return -1
		}

		if value%3 == 0 {
			result += value / 3
		} else {
			result += value/3 + 1
		}
	}

	return result
}
