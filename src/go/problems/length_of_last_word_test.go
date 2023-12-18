// https://leetcode.com/problems/length-of-last-word

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type LengthOfLastWord struct{}

func TestLengthOfLastWord(t *testing.T) {
	gen := core.TestSuite[LengthOfLastWord]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param("luffy is still joyboy").Result(6)
	}).Add(func(tc *core.TestCase) {
		tc.Param("   fly me   to   the moon  ").Result(4)
	}).Add(func(tc *core.TestCase) {
		tc.Param("Hello World").Result(5)
	}).Run(t)
}

func (LengthOfLastWord) Solution(s string) int {
	startAt := -1
	endAt := -1
	for i := len(s) - 1; i >= 0; i-- {
		if startAt == -1 && s[i] >= 'A' {
			startAt = i
		} else if startAt != -1 && s[i] == ' ' {
			endAt = i
			break
		}
	}

	return startAt - endAt
}
