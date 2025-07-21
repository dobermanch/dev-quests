// https://leetcode.com/problems/valid-palindrome/

package problems

import (
	"testing"
	"unicode"

	"github.com/dobermanch/leetcode/core"
)

type IsPalindrome struct{}

func TestIsPalindrome(t *testing.T) {
	gen := core.TestSuite[IsPalindrome]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param("A man, a plan, a canal: Panama").Result(true)
	}).Add(func(tc *core.TestCase) {
		tc.Param("race a car").Result(false)
	}).Add(func(tc *core.TestCase) {
		tc.Param(" ").Result(true)
	}).Run(t)
}

func (IsPalindrome) Solution(s string) bool {
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
