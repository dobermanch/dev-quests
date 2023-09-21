//https://leetcode.com/problems/is-subsequence/
package problems

import "testing"

func TestIsSubsequence(t *testing.T) {
	result := IsSubsequence("abc", "ahbgdc")
	t.Log(result)
}

func IsSubsequence(s string, t string) bool {
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
