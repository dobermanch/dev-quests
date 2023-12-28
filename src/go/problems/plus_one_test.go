// https://leetcode.com/problems/plus-one

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type PlusOne struct{}

func TestPlusOne(t *testing.T) {
	gen := core.TestSuite[PlusOne]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([]int{1, 2, 3}).Result([]int{1, 2, 4})
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{4, 3, 2, 1}).Result([]int{4, 3, 2, 2})
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{9}).Result([]int{1, 0})
	}).Run(t)
}

func (PlusOne) Solution(digits []int) []int {
	result := make([]int, len(digits)+1)
	result[0] = 1
	carry := 1
	for i := len(digits) - 1; i >= 0; i-- {
		temp := digits[i] + carry
		carry = temp / 10
		result[i+1] = temp % 10
	}

	if carry > 0 {
		return result
	}

	return result[1:]
}
