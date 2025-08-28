// https://leetcode.com/problems/minimum-changes-to-make-alternating-binary-string

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type MinOperations struct{}

func TestMinOperations(t *testing.T) {
	gen := core.TestSuite[MinOperations]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param("0100").Result(1)
	}).Add(func(tc *core.TestCase) {
		tc.Param("10").Result(0)
	}).Add(func(tc *core.TestCase) {
		tc.Param("1111").Result(2)
	}).Run(t)
}

func (MinOperations) Solution(s string) int {
	operations1 := 0
	for i := 0; i < len(s); i++ {
		if i%2 == 0 && s[i] != '1' || i%2 != 0 && s[i] == '1' {
			operations1++
		}
	}

	operations2 := len(s) - operations1
	if operations2 < operations1 {
		return operations2
	}

	return operations1
}
