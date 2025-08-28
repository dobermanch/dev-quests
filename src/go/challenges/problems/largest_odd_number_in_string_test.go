// https://leetcode.com/problems/largest-odd-number-in-string

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type LargestOddNumber struct{}

func TestLargestOddNumber(t *testing.T) {
	gen := core.TestSuite[LargestOddNumber]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param("52").Result("5")
	}).Add(func(tc *core.TestCase) {
		tc.Param("4206").Result("")
	}).Add(func(tc *core.TestCase) {
		tc.Param("35427").Result("35427")
	}).Run(t)
}

func (LargestOddNumber) Solution(num string) string {
	for i := len(num) - 1; i >= 0; i-- {
		if num[i]%2 != 0 {
			return num[:(i + 1)]
		}
	}

	return ""
}
