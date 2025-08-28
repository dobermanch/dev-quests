// https://leetcode.com/problems/roman-to-integer

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type RomanToInt struct{}

func TestRomanToInt(t *testing.T) {
	gen := core.TestSuite[RomanToInt]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param("III").Result(3)
	}).Add(func(tc *core.TestCase) {
		tc.Param("LVIII").Result(58)
	}).Add(func(tc *core.TestCase) {
		tc.Param("MCMXCIV").Result(1994)
	}).Add(func(tc *core.TestCase) {
		tc.Param("MMMCDXC").Result(3490)
	}).Run(t)
}

func (RomanToInt) Solution(s string) int {
	set := map[byte]int{
		'I': 1,
		'V': 5,
		'L': 50,
		'X': 10,
		'C': 100,
		'D': 500,
		'M': 1000,
	}

	result := 0
	for i := 0; i < len(s); i++ {
		if i+1 < len(s) && set[s[i]] < set[s[i+1]] {
			result -= set[s[i]]
		} else {
			result += set[s[i]]
		}
	}

	return result
}
