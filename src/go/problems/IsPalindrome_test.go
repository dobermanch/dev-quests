// //https://leetcode.com/problems/palindrome-linked-list/

package problems

import (
	"testing"
	"unicode"
)

func TestIsPalindrome(t *testing.T) {
	result := IsPalindrome("A man, a plan, a canal: Panama")
	t.Log(result)
}

func IsPalindrome(s string) bool {
	left := 0
	right := len(s) - 1

	for left < right {
		lRune := rune(s[left])
		rRune := rune(s[right])

		if !(unicode.IsLetter(lRune) || unicode.IsDigit(lRune)) {
			left++
			continue
		}

		if !(unicode.IsLetter(rRune) || unicode.IsDigit(rRune)) {
			right--
			continue
		}

		if unicode.ToLower(lRune) != unicode.ToLower(rRune) {
			return false
		}

		left++
		right--
	}

	return true
}
