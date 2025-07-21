// https://leetcode.com/problems/reverse-vowels-of-a-string/

package problems

import (
	"testing"
	"github.com/dobermanch/leetcode/core"
)

type ReverseVowels struct{}

func TestReverseVowels(t *testing.T) {
	gen := core.TestSuite[ReverseVowels]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param("hello").Result("holle")
	}).Add(func(tc *core.TestCase) {
		tc.Param("leetcode").Result("leotcede")
	}).Add(func(tc *core.TestCase) {
		tc.Param(" ").Result(" ")
	}).Add(func(tc *core.TestCase) {
		tc.Param("appear").Result("appear")
	}).Run(t)
}

func (ReverseVowels) Solution(s string) string {
	var vowels = map[byte]struct{}{'a': {}, 'e': {}, 'i': {}, 'o': {}, 'u': {}, 'A': {}, 'E': {}, 'I': {}, 'O': {}, 'U': {} }

	result := []byte(s)
	left := 0
	right := len(s) - 1
	for left < right {
		if _, ok := vowels[s[left]]; ok {
			if _, ok := vowels[s[right]]; ok {
				result[left], result[right] = result[right], result[left]
				left++
			}

			right--
		} else {
			left++
		}
	}

	return string(result)
}
