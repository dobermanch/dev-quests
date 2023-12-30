// https://leetcode.com/problems/redistribute-characters-to-make-all-strings-equal

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type MakeEqual struct{}

func TestMakeEqual(t *testing.T) {
	gen := core.TestSuite[MakeEqual]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([]string{"abc", "aabc", "bc"}).Result(true)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]string{"ab", "a"}).Result(false)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]string{"a", "b"}).Result(false)
	}).Run(t)
}

func (MakeEqual) Solution(words []string) bool {
	set := make([]int, 26)

	for _, word := range words {
		for _, ch := range word {
			set[ch-'a']++
		}
	}

	length := len(words)
	for _, count := range set {
		if count%length != 0 {
			return false
		}
	}

	return true
}
