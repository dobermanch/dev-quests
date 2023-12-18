// https://leetcode.com/problems/gas-station

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type CanCompleteCircuit struct{}

func TestCanCompleteCircuit(t *testing.T) {
	gen := core.TestSuite[CanCompleteCircuit]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([]int{1, 2, 3, 4, 5}).Param([]int{3, 4, 5, 1, 2}).Result(3)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{2, 3, 4}).Param([]int{3, 4, 3}).Result(-1)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{2}).Param([]int{2}).Result(0)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{1, 2, 3, 4, 5, 5, 70}).Param([]int{2, 3, 4, 3, 9, 6, 2}).Result(6)
	}).Run(t)
}

func (CanCompleteCircuit) Solution(gas []int, cost []int) int {
	startAt := 0
	sum := 0
	total := 0
	for i := 0; i < len(gas); i++ {
		total += gas[i] - cost[i]
		sum += gas[i] - cost[i]

		if sum < 0 {
			sum = 0
			startAt = i + 1
		}
	}

	if total >= 0 {
		return startAt
	}

	return -1
}
