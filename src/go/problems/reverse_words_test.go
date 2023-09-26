// https://leetcode.com/problems/reverse-words-in-a-string

package problems

import (
	"strings"
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type ReverseWords struct{}

func TestReverseWords(t *testing.T) {
	gen := core.TestSuite[ReverseWords]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param("the sky is blue").Result("blue is sky the")
	}).Add(func(tc *core.TestCase) {
		tc.Param("  hello world  ").Result("world hello")
	}).Add(func(tc *core.TestCase) {
		tc.Param("a good   example").Result("a good   example")
	}).Run(t)
}

func (ReverseWords) Solution(s string) string {
	var result strings.Builder
	left := len(s) - 1
	right := left

	for left >= -1 {
		if left >= 0 && s[left] != ' ' {
			left--
			continue
		}

		if left != right {
			if result.Len() > 0 {
				result.WriteRune(' ')
			}

			result.WriteString(s[left + 1:right + 1])
		}

		left--
		right = left
	}

	return result.String()
}
