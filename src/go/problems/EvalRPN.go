// https://leetcode.com/problems/two-sum/

package problems

import (
	"strconv"
	"testing"
)

func TestEvalRPN(t *testing.T) {
	result := EvalRPN([]string{"10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+"})
	t.Log(result)
}

type stack struct {
	set []int
}

func (s *stack) Push(v int) {
	s.set = append(s.set, v)
}

func (s *stack) Pop() int {
	l := len(s.set)
	res := s.set[l-1]
	s.set = s.set[:l-1]
	return res
}

func EvalRPN(tokens []string) int {
	stack := stack{}

	for _, token := range tokens {
		number, ok := strconv.ParseInt(token, 0, 32)
		if ok == nil {
			stack.Push(int(number))
			continue
		}

		if token == "+" {
			right := stack.Pop()
			left := stack.Pop()
			stack.Push((left + right))
		} else if token == "-" {
			right := stack.Pop()
			left := stack.Pop()
			stack.Push((left - right))
		} else if token == "*" {
			right := stack.Pop()
			left := stack.Pop()
			stack.Push((left * right))
		} else if token == "/" {
			right := stack.Pop()
			left := stack.Pop()
			stack.Push((left / right))
		}
	}

	return stack.Pop()
}
