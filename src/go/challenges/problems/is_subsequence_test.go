// https://leetcode.com/problems/is-subsequence/
package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type IsSubsequence struct{}

func TestIsSubsequence(t *testing.T) {
	gen := core.TestSuite[IsSubsequence]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param("abc").Param("ahbgdc").Result(true)
	}).Add(func(tc *core.TestCase) {
		tc.Param("axc").Param("ahbgdc").Result(false)
	}).Run(t)
}


func (IsSubsequence)Solution(s string, t string) bool {
	if len(s) == 0 {
		return true
	}

	if len(t) == 0 {
		return true
	}

	j := 0
	for i := 0; i < len(t); i++ {
		if t[i] == s[j] {
			j++
			if j >= len(s) {
				break
			}
		}
	}

	return j == len(s)
}
