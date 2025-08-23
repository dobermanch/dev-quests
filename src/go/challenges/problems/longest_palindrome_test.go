// https://leetcode.com/problems/longest-palindrome/

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type LongestPalindrome struct{}

func TestLongestPalindrome(t *testing.T) {
	gen := core.TestSuite[LongestPalindrome]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param("abccccdd").Result(7)
	}).Add(func(tc *core.TestCase) {
		tc.Param("a").Result(1)
	}).Run(t)
}

func (LongestPalindrome) Solution(s string) int {
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
