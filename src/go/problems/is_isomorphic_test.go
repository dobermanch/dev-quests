//https://leetcode.com/problems/isomorphic-strings/

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type IsIsomorphic struct{}

func TestIsIsomorphic(t *testing.T) {
	gen := core.TestSuite[IsIsomorphic]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param("egg").Param("add").Result(true)
	}).Add(func(tc *core.TestCase) {
		tc.Param("foo").Param("bar").Result(false)
	}).Add(func(tc *core.TestCase) {
		tc.Param("paper").Param("title").Result(true)
	}).Run(t)
}

func (IsIsomorphic) Solution(s string, t string) bool {
	var set1 = [127]byte{}
	var set2 = [127]byte{}

	for i := 0; i < len(s); i++ {
		if set1[s[i]] == 0 {
			set1[s[i]] = t[i]
		}

		if set2[t[i]] == 0 {
			set2[t[i]] = s[i]
		}

		if set1[s[i]] != t[i] || set2[t[i]] != s[i] {
			return false
		}
	}

	return true
}
