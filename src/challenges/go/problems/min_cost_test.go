// https://leetcode.com/problems/running-sum-of-1d-array/

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type MinCost struct{}

func TestMinCost(t *testing.T) {
	gen := core.TestSuite[MinCost]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param("bbbaaa").Param([]int{4, 9, 3, 8, 8, 9}).Result(23)
	}).Add(func(tc *core.TestCase) {
		tc.Param("aabaa").Param([]int{1, 2, 3, 4, 1}).Result(2)
	}).Add(func(tc *core.TestCase) {
		tc.Param("abc").Param([]int{1, 2, 3}).Result(0)
	}).Add(func(tc *core.TestCase) {
		tc.Param("abaac").Param([]int{1, 2, 3, 4, 5}).Result(3)
	}).Run(t)
}

func (MinCost) Solution(colors string, neededTime []int) int {
	result := 0
	maxCost := neededTime[0]
	length := len(colors)
	for i := 1; i < length; i++ {
		if colors[i] == colors[i-1] {
			if neededTime[i] < maxCost {
				result += neededTime[i]
			} else {
				result += maxCost
			}

			if neededTime[i] > maxCost {
				maxCost = neededTime[i]
			}
		} else {
			maxCost = neededTime[i]
		}
	}

	return result
}
