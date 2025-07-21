// https://leetcode.com/problems/evaluate-reverse-polish-notation/

package problems

import (
	"strconv"
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type evalRPN struct{}

func TestEvalRPN(t *testing.T) {
	gen := core.TestSuite[evalRPN]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([]string{"2","1","+","3","*"}).Result(9)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]string{"4","13","5","/","+"}).Result(6)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]string{"10","6","9","3","+","-11","*","/","*","17","+","5","+"}).Result(22)
	}).Run(t)
}

func (evalRPN)Solution(tokens []string) int {
	return EvalRPN(tokens)
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
