// https://leetcode.com/problems/running-sum-of-1d-array/

package problems

import (
	"testing"
	"github.com/dobermanch/leetcode/core"
)

type AddTwoIntegers struct{}

func TestAddTwoIntegers(t *testing.T) {
	gen := core.TestSuite[AddTwoIntegers]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param(10).Param(13).Result(23)
	}).Add(func(tc *core.TestCase) {
		tc.Param(-10).Param(12).Result(2)
	}).Run(t)
}

func (AddTwoIntegers) Solution(num1 int, num2 int) int {
	return num1 + num2
}
