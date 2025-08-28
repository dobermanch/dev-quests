// https://leetcode.com/problems/removing-stars-from-a-string

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type RemoveStars struct{}

func TestRemoveStars(t *testing.T) {
	gen := core.TestSuite[RemoveStars]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param("leet**cod*e").Result("lecoe")
	}).Add(func(tc *core.TestCase) {
		tc.Param("erase*****").Result("")
	}).Run(t)
}

func (RemoveStars) Solution(s string) string {
	stack := make([]byte, len(s))
	index := 0
	for i := 0; i < len(s); i++ {
		if s[i] == '*' {
			index--
		} else {
			stack[index] = s[i]
			index++
		}
	}

	return string(stack[:index])
}
