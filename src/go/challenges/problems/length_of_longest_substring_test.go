// https://leetcode.com/problems/longest-substring-without-repeating-characters/

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type LengthOfLongestSubstring struct{}

func TestLengthOfLongestSubstring(t *testing.T) {
	gen := core.TestSuite[LengthOfLongestSubstring]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param("abcabcbb").Result(3)
	}).Add(func(tc *core.TestCase) {
		tc.Param("bbbbb").Result(1)
	}).Add(func(tc *core.TestCase) {
		tc.Param("pwwkew").Result(3)
	}).Run(t)
}

func (LengthOfLongestSubstring) Solution(s string) int {
	set := map[byte]struct{}{}

	res := 0
	left := 0

	for right := 0; right < len(s); right++ {
		if _, ok := set[s[right]]; ok {
			res = max(res, right-left)
			for {
				if _, ok := set[s[right]]; !ok {
					break
				}
				delete(set, s[left])
				left++
			}
		}

		set[s[right]] = struct{}{}
	}

	return max(res, len(s)-left)
}
