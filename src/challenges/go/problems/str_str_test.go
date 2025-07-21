// https://leetcode.com/problems/find-the-index-of-the-first-occurrence-in-a-string

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type StrStr struct{}

func TestStrStr(t *testing.T) {
	gen := core.TestSuite[StrStr]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param("sadbutsad").Param("sad").Result(0)
	}).Add(func(tc *core.TestCase) {
		tc.Param("leetcode").Param("leeto").Result(-1)
	}).Add(func(tc *core.TestCase) {
		tc.Param("a").Param("a").Result(0)
	}).Run(t)
}

func (StrStr) Solution(haystack string, needle string) int {
	length := len(haystack) - len(needle)
	for index := 0; index <= length; index++ {
		if haystack[index] != needle[0] {
			continue
		}

		left := 0
		right := len(needle) - 1
		for left <= right &&
			haystack[index+left] == needle[left] &&
			haystack[index+right] == needle[right] {
			left++
			right--
		}

		if left > right {
			return index
		}
	}

	return -1
}
