// https://leetcode.com/problems/longest-substring-without-repeating-characters/

package problems

import (
	"testing"
)

func TestLengthOfLongestSubstring(t *testing.T) {
	result := LengthOfLongestSubstring("abcabcbb")
	t.Log(result)
}

func LengthOfLongestSubstring(s string) int {
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
