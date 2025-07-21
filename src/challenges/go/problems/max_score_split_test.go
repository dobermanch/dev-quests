// https://leetcode.com/problems/maximum-score-after-splitting-a-string

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type MaxScoreSplit struct{}

func TestMaxScoreSplit(t *testing.T) {
	gen := core.TestSuite[MaxScoreSplit]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param("00111").Result(5)
	}).Add(func(tc *core.TestCase) {
		tc.Param("011101").Result(5)
	}).Add(func(tc *core.TestCase) {
		tc.Param("1111").Result(3)
	}).Run(t)
}

func (MaxScoreSplit) Solution(s string) int {
	oneCount := 0
	for i := 0; i < len(s); i++ {
		if s[i] == '1' {
			oneCount++
		}
	}

	zeroCount := 0
	score := 0
	for i := 0; i < len(s)-1; i++ {
		if s[i] == '0' {
			zeroCount++
		} else {
			oneCount--
		}

		sum := zeroCount + oneCount
		if score < sum {
			score = sum
		}
	}

	return score
}
