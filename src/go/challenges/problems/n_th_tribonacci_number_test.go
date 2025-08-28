// https://leetcode.com/problems/n-th-tribonacci-number

package problems

import (
	"testing"
	"github.com/dobermanch/leetcode/core"
)

type Tribonacci struct{}

func TestTribonacci(t *testing.T) {
	gen := core.TestSuite[Tribonacci]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param(4).Result(4)
	}).Add(func(tc *core.TestCase) {
		tc.Param(25).Result(1389537)
	}).Run(t)
}

func (Tribonacci) Solution(n int) int {
    if (n == 0) {
        return 0
    }

    if (n <= 2) {
        return 1
    }

    n1 := 1
    n2 := 1
    n3 := 2
    for (n > 3) {
        n--
        next := n1 + n2 + n3
        n1 = n2
        n2 = n3
        n3 = next
    }

    return n3
}
