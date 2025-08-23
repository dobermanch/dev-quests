// https://leetcode.com/problems/valid-anagram/
package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type IsAnagram struct{}

func TestIsAnagram(t *testing.T) {
	gen := core.TestSuite[IsAnagram]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param("anagram").Param("nagaram").Result(true)
	}).Add(func(tc *core.TestCase) {
		tc.Param("rat").Param("car").Result(false)
	}).Run(t)
}

func (IsAnagram) Solution(s string, t string) bool {
	if len(s) != len(t) {
		return false
	}

	set := map[byte]int{}
	length := len(s)
	for i := 0; i < length; i++ {
		set[s[i]]++
		set[t[i]]--
	}

	for _, v := range set {
		if v != 0 {
			return false
		}
	}

	return true
}
