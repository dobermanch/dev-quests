// https://leetcode.com/problems/find-the-highest-altitude/

package problems

import (
	"testing"
	"github.com/dobermanch/leetcode/core"
)

type LargestAltitude struct{}

func TestLargestAltitude(t *testing.T) {
	gen := core.TestSuite[LargestAltitude]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([]int{-5,1,5,0,-7}).Result(1)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{-4,-3,-2,-1,4,3,2}).Result(0)
	}).Run(t)
}

func (LargestAltitude) Solution(gain []int) int {
    result := 0
    current := 0
    for i := 0; i < len(gain); i++ {
        current += gain[i];
        if current > result {
            result = current
        }
    }

    return result
}