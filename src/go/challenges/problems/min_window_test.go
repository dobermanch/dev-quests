// https://leetcode.com/problems/minimum-window-substring/

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type MinWindow struct{}

func TestMinWindow(t *testing.T) {
	gen := core.TestSuite[MinWindow]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param("ADOBECODEBANC").Param("ABC").Result("BANC")
	}).Add(func(tc *core.TestCase) {
		tc.Param("a").Param("a").Result("a")
	}).Add(func(tc *core.TestCase) {
		tc.Param("a").Param("aa").Result("")
	}).Run(t)
}

func (MinWindow)Solution(s string, t string) string {
	sLength := len(s)
	tLength := len(t)
	set := make(map[byte][]int)
	for i := 0; i < len(t); i++ {
		if _, ok := set[t[i]]; !ok {
			set[t[i]] = append(set[t[i]], 1, 0)
		} else {
			set[t[i]][0]++
		}
	}

	left := 0
	matches := 0
	var result string

	for right := 0; right < sLength; right++ {
		if _, ok := set[s[right]]; ok {
			set[s[right]][1]++

			if set[s[right]][0] >= set[s[right]][1] {
				matches++
			}
		}

		for matches == tLength {
			if right-left+1 < len(result) || len(result) == 0 {
				result = s[left : right+1]
			}

			if _, ok := set[s[left]]; ok {
				set[s[left]][1]--
				if set[s[left]][0] > set[s[left]][1] {
					matches--
				}
			}

			left++
		}
	}

	return result
}
