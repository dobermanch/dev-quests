// https://leetcode.com/problems/bitwise-and-of-numbers-range

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type BitwiseAndOfNumbersRange struct{}

func TestBitwiseAndOfNumbersRange(t *testing.T) {
	gen := core.TestSuite[BitwiseAndOfNumbersRange]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param(1).Param(1).Result(1)
	}).Add(func(tc *core.TestCase) {
		tc.Param(416).Param(436).Result(416)
	}).Add(func(tc *core.TestCase) {
		tc.Param(5).Param(7).Result(4)
	}).Add(func(tc *core.TestCase) {
		tc.Param(0).Param(0).Result(0)
	}).Add(func(tc *core.TestCase) {
		tc.Param(1).Param(2147483647).Result(0)
	}).Run(t)
}

func (BitwiseAndOfNumbersRange) Solution(left int, right int) int {
	for right > left {
		right &= (right - 1)
	}

	return left & right
}
