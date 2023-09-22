// https://leetcode.com/problems/valid-parentheses/
package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type IsValidParentheses struct{}

func TestIsValidParentheses(t *testing.T) {
	gen := core.TestSuite[IsValidParentheses]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param("()").Result(true)
	}).Add(func(tc *core.TestCase) {
		tc.Param("()[]{}").Result(true)
	}).Add(func(tc *core.TestCase) {
		tc.Param("(]").Result(false)
	}).Run(t)
}

func (IsValidParentheses) Solution(s string) bool {
	stack := []rune{}

	for _, s := range s {
		if s == '(' || s == '{' || s == '[' {
			stack = append(stack, s)
			continue
		}

		if len(stack) == 0 {
			return false
		}

		bracket := stack[len(stack)-1]
		stack = stack[:len(stack)-1]
		switch s {
		case ')':
			if bracket != '(' {
				return false
			}
		case '}':
			if bracket != '{' {
				return false
			}
		case ']':
			if bracket != '[' {
				return false
			}
		}
	}

	return len(stack) == 0
}
