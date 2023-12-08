// https://leetcode.com/problems/candy

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type Candy struct{}

func TestCandy(t *testing.T) {
	gen := core.TestSuite[Candy]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([]int{1, 0, 2}).Result(5)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{1, 2, 2}).Result(4)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{6, 7, 6, 5, 4, 3, 2, 1, 0, 0, 0, 1, 0}).Result(42)
	}).Run(t)
}

func (Candy) Solution(ratings []int) int {
	result := 1
	increase := 0
	decrease := 0
	maxCandy := 0
	for i := 1; i < len(ratings); i++ {
		if ratings[i-1] < ratings[i] {
			increase++
			maxCandy = increase
			result += increase + 1
			decrease = 0
		} else if ratings[i-1] > ratings[i] {
			decrease++
			increase = 0

			if maxCandy >= decrease {
				result += decrease
			} else {
				result += decrease + 1
			}
		} else {
			result += 1
			decrease = 0
			maxCandy = 0
			increase = 0
		}
	}

	return result
}
