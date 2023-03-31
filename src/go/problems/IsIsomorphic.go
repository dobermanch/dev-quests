// https://leetcode.com/problems/two-sum/

package problems

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
