// https://leetcode.com/problems/two-sum/

package problems

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
