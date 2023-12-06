// https://leetcode.com/problems/calculate-money-in-leetcode-bank

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type TotalMoney struct{}

func TestTotalMoney(t *testing.T) {
	gen := core.TestSuite[TotalMoney]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param(4).Result(10)
	}).Add(func(tc *core.TestCase) {
		tc.Param(10).Result(37)
	}).Add(func(tc *core.TestCase) {
		tc.Param(20).Result(96)
	}).Run(t)
}

func (TotalMoney) Solution(n int) int {
	week := 0
	result := 0

	for i := 0; i < n; i++ {
		day := i % 7
		if day == 0 {
			week++
		}

		result += week + day
	}

	return result
}
