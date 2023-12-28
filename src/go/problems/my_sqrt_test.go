// https://leetcode.com/problems/sqrtx

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type MySqrt struct{}

func TestMySqrt(t *testing.T) {
	gen := core.TestSuite[MySqrt]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param(4).Result(2)
	}).Add(func(tc *core.TestCase) {
		tc.Param(8).Result(2)
	}).Add(func(tc *core.TestCase) {
		tc.Param(13284790).Result(3644)
	}).Run(t)
}

func (MySqrt) Solution(x int) int {
	left := 0
	right := x
	for left <= right {
		root := (left + right) / 2
		target := root * root

		if target == x {
			return root
		} else if target < x {
			left = root + 1
		} else {
			right = root - 1
		}
	}

	return right
}
