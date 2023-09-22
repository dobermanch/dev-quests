// https://leetcode.com/problems/two-sum/
package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type TwoSum struct{}

func TestTwoSum(t *testing.T) {
	gen := core.TestSuite[TwoSum]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([]int{2,7,11,15}).Param(9).Result([]int{0, 1})
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{3,2,4}).Param(6).Result([]int{1, 2})
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{3,3}).Param(6).Result([]int{0, 1})
	}).Run(t)
}

func (TwoSum) Solution(nums []int, target int) []int {
    set := make(map[int]int, len(nums))

    for i, n := range nums {
        if v, ok := set[target - n]; ok {
            return []int{v, i}
        }

        set[n] = i
    }

    return []int{}
}