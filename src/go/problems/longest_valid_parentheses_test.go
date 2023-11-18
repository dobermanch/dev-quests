// https://leetcode.com/problems/longest-valid-parentheses

package problems

import (
	"testing"
	"github.com/dobermanch/leetcode/core"
)

type LongestValidParentheses struct{}

func TestLongestValidParentheses(t *testing.T) {
	gen := core.TestSuite[LongestValidParentheses]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param("(()").Result(2)
	}).Add(func(tc *core.TestCase) {
		tc.Param(")()())").Result(6)
	}).Add(func(tc *core.TestCase) {
		tc.Param("").Result(0)
	}).Add(func(tc *core.TestCase) {
		tc.Param("()(())").Result(6)
	}).Run(t)
}

func (LongestValidParentheses) Solution(s string) int {
    stack := []int{-1}
	max := 0
	length := len(s)
	for i := 0; i < length; i++ {
		if s[i] == '(' {
			stack = append(stack, i)
			continue
		}

		stack = stack[:len(stack) - 1]
		if len(stack) == 0 {
			stack = append(stack, i)
		} else {
			len := i - stack[len(stack) - 1]
			if max < len {
				max = len
			}
		}
	}

	return max
}
