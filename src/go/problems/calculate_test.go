// https://leetcode.com/problems/basic-calculator

package problems

import (
	"github.com/dobermanch/leetcode/core"
	"testing"
)

type Calculate struct{}

func TestCalculate(t *testing.T) {
	gen := core.TestSuite[Calculate]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param(" 2-1 + 23").Result(24)
	}).Add(func(tc *core.TestCase) {
		tc.Param("1 + 1").Result(2)
	}).Add(func(tc *core.TestCase) {
		tc.Param(" 2-1 + 2 ").Result(3)
	}).Add(func(tc *core.TestCase) {
		tc.Param("(1+(4+5+2)-3)+(6+8)").Result(23)
	}).Add(func(tc *core.TestCase) {
		tc.Param("- (3 - (- (4 + 5) ) )").Result(-12)
	}).Run(t)
}

func (Calculate) Solution(s string) int {
	numbers := []int{}
	operand := 1
	number := 0
	result := 0
	for i := 0; i < len(s); i++ {
		if s[i] >= '0' {
			number *= 10
			number += int(s[i] - '0')
		}

		if s[i] < '0' || i == len(s)-1 {
			result += number * operand
			number = 0
		}

		if s[i] == '(' {
			numbers = append(numbers, result)
			numbers = append(numbers, operand)
			operand = 1
			result = 0
		} else if s[i] == ')' {
			result *= numbers[len(numbers)-1]
			numbers = numbers[:len(numbers)-1]

			result += numbers[len(numbers)-1]
			numbers = numbers[:len(numbers)-1]
		} else if s[i] == '-' {
			operand = -1
		} else if s[i] == '+' {
			operand = 1
		}
	}

	return result
}
