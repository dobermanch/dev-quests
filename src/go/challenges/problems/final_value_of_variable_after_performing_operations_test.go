// https://leetcode.com/problems/final-value-of-variable-after-performing-operations

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type FinalValueOfVariableAfterPerformingOperations struct{}

func TestFinalValueOfVariableAfterPerformingOperations(t *testing.T) {
	gen := core.TestSuite[FinalValueOfVariableAfterPerformingOperations]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([]string{"--X", "X++", "X++"}).Result(1)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]string{"++X", "++X", "X++"}).Result(3)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]string{"X++", "++X", "--X", "X--"}).Result(0)
	}).Run(t)
}

func (FinalValueOfVariableAfterPerformingOperations) Solution(operations []string) int {
	x := 0
	for _, op := range operations {
		if op == "++X" || op == "X++" {
			x++
		} else {
			x--
		}
	}

	return x
}
