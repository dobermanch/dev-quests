// https://leetcode.com/problems/generate-parentheses/

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type GenerateParenthesis struct{}

func TestGenerateParenthesis(t *testing.T) {
	gen := core.TestSuite[GenerateParenthesis]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param(3).Result([]string{"((()))", "(()())", "(())()", "()(())", "()()()"})
	}).Add(func(tc *core.TestCase) {
		tc.Param(1).Result([]string{"()"})
	}).Run(t)
}

func (GenerateParenthesis) Solution(n int) []string {
	result := make([]string, 0)

	build(n-1, n, "(", "", &result)
	return result
}

func build(open int, closed int, parenthesis string, temp string, result *[]string) {
	temp += parenthesis

	if open > 0 {
		build(open-1, closed, "(", temp, result)
	}

	if closed > open {
		build(open, closed-1, ")", temp, result)
	}

	if open == 0 && closed == 0 {
		*result = append(*result, temp)
	}
}
