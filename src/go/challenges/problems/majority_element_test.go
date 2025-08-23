// https://leetcode.com/problems/majority-element/

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type MajorityElement struct{}

func TestMajorityElement(t *testing.T) {
	gen := core.TestSuite[MajorityElement]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([]int{3, 2, 3}).Result(3)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{2, 2, 1, 1, 1, 2, 2}).Result(2)
	}).Run(t)
}

func (MajorityElement) Solution(nums []int) int {
	result := 0
	count := 0

	for _, num := range nums {
		if count == 0 {
			result = num
		}

		if result == num {
			count++
		} else {
			count--
		}
	}

	return result
}
