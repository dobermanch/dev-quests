// https://leetcode.com/problems/maximum-number-of-vowels-in-a-substring-of-given-length

package problems

import (
	"testing"
	"github.com/dobermanch/leetcode/core"
)

type MaxVowels struct{}

func TestMaxVowels(t *testing.T) {
	gen := core.TestSuite[MaxVowels]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param("abciiidef").Param(3).Result(3)
	}).Add(func(tc *core.TestCase) {
		tc.Param("aeiou").Param(2).Result(2)
	}).Add(func(tc *core.TestCase) {
		tc.Param("leetcode").Param(3).Result(2)
	}).Run(t)
}

func (MaxVowels) Solution(s string, k int) int {
	vowels := map[byte]struct{}{ 'a': {}, 'e': {}, 'i': {}, 'o': {}, 'u': {} }

	right := 0
	result := 0
	count := 0
	for right < len(s) {
		if _,ok := vowels[s[right]]; ok {
			count++
			if count > result {
				result = count
			}
		}

		left := right - k + 1
		if left >= 0 {
			if _,ok := vowels[s[left]]; ok {
				count--
			}
		}

		right++
	}

	return result
}
