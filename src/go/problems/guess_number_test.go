// https://leetcode.com/problems/guess-number-higher-or-lower

package problems

import (
	"testing"
	"github.com/dobermanch/leetcode/core"
)

type GuessNumber struct{}

func TestGuessNumber(t *testing.T) {
	gen := core.TestSuite[GuessNumber]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param(10).Param(6).Result(6)
	}).Add(func(tc *core.TestCase) {
		tc.Param(1).Param(1).Result(1)
	}).Add(func(tc *core.TestCase) {
		tc.Param(2).Param(1).Result(1)
	}).Run(t)
}

func (GuessNumber) Solution(n int, pick int) int {
	guess := func (n int) int {
		if (n > pick) {
			return -1
		} else if (n < pick) {
			return 1
		} 

		return 0
	}

    left := 0
    right := n
    num := 0
    for (left <= right) {
        num = left + (right - left) / 2
        result := guess(num)
        if (result == 0) {
            break
        } else if (result == 1) {
            left = num + 1
        } else  {
            right = num - 1
        }
    }

    return num
}
