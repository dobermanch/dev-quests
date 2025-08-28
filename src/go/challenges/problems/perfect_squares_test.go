// https://leetcode.com/problems/perfect-squares

package problems

import (
	"testing"
	"math"
	"github.com/dobermanch/leetcode/core"
)

type NumSquares struct{}

func TestNumSquares(t *testing.T) {
	gen := core.TestSuite[NumSquares]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param(4).Result(1)
	}).Add(func(tc *core.TestCase) {
		tc.Param(12).Result(3)
	}).Add(func(tc *core.TestCase) {
		tc.Param(13).Result(2)
	}).Add(func(tc *core.TestCase) {
		tc.Param(3).Result(3)
	}).Run(t)
}

func (NumSquares) Solution(n int) int {
    result := make([]int, n + 1)

    for i := 1; i <= n; i++ {
        result[i] = math.MaxInt32

        for j := 1; j <= i; j++ {
            pow := j * j
            if i - pow < 0 {
                break;
            }

            if result[i] > result[i - pow] + 1 {
                result[i] = result[i - pow] + 1
            }
        }
    }

    return result[n]
}
