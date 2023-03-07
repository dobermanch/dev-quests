// https://leetcode.com/problems/longest-consecutive-sequence/

package problems

import "testing"

func TestLongestPalindrome(t *testing.T) {
	result := LongestPalindrome("abccccdd")
	t.Log(result)
}

func LongestPalindrome(s string) int {
	set := [58]int{}

	for _, ch := range s {
		set[ch-'A']++
	}

	sum := 0
	addOne := false
	for _, v := range set {
		sum += v

		if v%2 != 0 {
			sum--
			addOne = true
		}
	}

	if addOne {
		sum++
	}

	return sum
}
