// https://leetcode.com/problems/valid-anagram/
package problems

import "testing"

func TestIsAnagram(t *testing.T) {
	result := IsAnagram("anagram", "nagaram")
	t.Log(result)
}

func IsAnagram(s string, t string) bool {
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
