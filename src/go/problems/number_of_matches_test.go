// https://leetcode.com/problems/count-of-matches-in-tournament

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type NumberOfMatches struct{}

func TestNumberOfMatches(t *testing.T) {
	gen := core.TestSuite[NumberOfMatches]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param(7).Result(6)
	}).Add(func(tc *core.TestCase) {
		tc.Param(14).Result(13)
	}).Run(t)
}

func (NumberOfMatches) Solution(n int) int {
	matches := 0
	teams := n

	for teams > 1 {
		matches += teams / 2
		teams = teams/2 + teams%2
	}

	return matches
}
