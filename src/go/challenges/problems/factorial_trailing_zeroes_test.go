// https://leetcode.com/problems/factorial-trailing-zeroes

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type FactorialTrailingZeroes struct{}

func TestFactorialTrailingZeroes(t *testing.T) {
	gen := core.TestSuite[FactorialTrailingZeroes]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param(23).Result(4)
	}).Add(func(tc *core.TestCase) {
		tc.Param(5).Result(1)
	}).Add(func(tc *core.TestCase) {
		tc.Param(3).Result(0)
	}).Add(func(tc *core.TestCase) {
		tc.Param(4).Result(0)
	}).Run(t)
}

func (FactorialTrailingZeroes) Solution(n int) int {
	if n <= 4 {
		return 0
	}

	count := 0
	power := 1
	for power < n {
		power *= 5
		count += n / power
	}

	return count
}
