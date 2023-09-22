// https://leetcode.com/problems/reverse-integer

package problems

import (
	"math"
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type Reverse struct{}

func TestReverse(t *testing.T) {
	gen := core.TestSuite[Reverse]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param(123).Result(321)
	}).Add(func(tc *core.TestCase) {
		tc.Param(-123).Result(-321)
	}).Add(func(tc *core.TestCase) {
		tc.Param(120).Result(21)
	}).Add(func(tc *core.TestCase) {
		tc.Param(1534236469).Result(0)
	}).Add(func(tc *core.TestCase) {
		tc.Param(-1534236469).Result(0)
	}).Run(t)
}

func (Reverse) Solution(x int) int {
	
	var result int64 = 0
	var num int64 = int64(x)
	for num != 0 {
		result = result * 10 + num % 10
		num /= 10
	}

	if result > math.MaxInt32 || result < math.MinInt32 {
		return 0
	}

	return int(result)
}
