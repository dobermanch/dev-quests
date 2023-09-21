// https://leetcode.com/problems/valid-parentheses/
package problems

import (
	"testing"
)

func TestIsValidParentheses(t *testing.T) {
	result := IsValidParentheses("()")
	t.Log(result)
}

func IsValidParentheses(s string) bool {
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
