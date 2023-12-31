// https://leetcode.com/problems/largest-substring-between-two-equal-characters

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type MaxLengthBetweenEqualCharacters struct{}

func TestMaxLengthBetweenEqualCharacters(t *testing.T) {
	gen := core.TestSuite[MaxLengthBetweenEqualCharacters]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param("aa").Result(0)
	}).Add(func(tc *core.TestCase) {
		tc.Param("abca").Result(2)
	}).Add(func(tc *core.TestCase) {
		tc.Param("cbzxy").Result(-1)
	}).Run(t)
}

func (MaxLengthBetweenEqualCharacters) Solution(s string) int {
	set := map[byte]int{}

	result := -1
	for i := 0; i < len(s); i++ {
		if _, ok := set[s[i]]; ok {
			diff := i - set[s[i]] - 1
			if result < diff {
				result = diff
			}
		} else {
			set[s[i]] = i
		}
	}

	return result
}
