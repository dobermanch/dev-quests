// https://leetcode.com/problems/minimum-rounds-to-complete-all-tasks

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type MinimumRounds struct{}

func TestMinimumRounds(t *testing.T) {
	gen := core.TestSuite[MinimumRounds]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([]int{2, 3, 3, 2, 2, 4, 2, 3, 4}).Result(4)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{2, 1, 2, 2, 3, 3}).Result(-1)
	}).Run(t)
}

func (MinimumRounds) Solution(tasks []int) int {
	set := map[int]int{}
	for i := 0; i < len(tasks); i++ {
		set[tasks[i]]++
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
