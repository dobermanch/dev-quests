//https://leetcode.com/problems/isomorphic-strings/

package problems

import "testing"

func TestIsIsomorphic(t *testing.T) {
	result := IsIsomorphic("egg", "bar")
	t.Log(result)
}

func IsIsomorphic(s string, t string) bool {
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
