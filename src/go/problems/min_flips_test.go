// https://leetcode.com/problems/minimum-flips-to-make-a-or-b-equal-to-c/

package problems

import (
	"testing"
	"github.com/dobermanch/leetcode/core"
)

type MinFlips struct{}

func TestMinFlips(t *testing.T) {
	gen := core.TestSuite[MinFlips]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param(2).Param(6).Param(5).Result(3)
	}).Add(func(tc *core.TestCase) {
		tc.Param(4).Param(2).Param(7).Result(1)
	}).Add(func(tc *core.TestCase) {
		tc.Param(1).Param(2).Param(3).Result(0)
	}).Run(t)
}

func (MinFlips) Solution(a int, b int, c int) int {
    result := 0
    for i := 0; i < 32; i++ {
        ar := (1 << i) & a
        br := (1 << i) & b
        cr := (1 << i) & c

        if (ar | br) == cr {
            continue;
        }

        if ar == 0 && br == 0 {
            result++
            continue
        }

        if ar > 0 {
            result++
        }

        if br > 0 {
            result++
        }
    }

    return result
}
