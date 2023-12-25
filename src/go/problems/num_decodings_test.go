// https://leetcode.com/problems/decode-ways

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type NumDecodings struct{}

func TestNumDecodings(t *testing.T) {
	gen := core.TestSuite[NumDecodings]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param("12").Result(2)
	}).Add(func(tc *core.TestCase) {
		tc.Param("226").Result(3)
	}).Add(func(tc *core.TestCase) {
		tc.Param("06").Result(0)
	}).Run(t)
}

func (NumDecodings) Solution(s string) int {
	temp1 := 1
	temp2 := 1
	for i := len(s) - 1; i >= 0; i-- {
		temp := temp1

		if s[i] == '0' {
			temp1 = 0
		} else if i+1 < len(s) && (s[i] == '1' || s[i] == '2' && s[i+1] <= '6') {
			temp1 += temp2
		}

		temp2 = temp
	}

	return temp1
}
