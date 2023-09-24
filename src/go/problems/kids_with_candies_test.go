// https://leetcode.com/problems/kids-with-the-greatest-number-of-candies

package problems

import (
	"testing"
	"github.com/dobermanch/leetcode/core"
)

type KidsWithCandies struct{}

func TestKidsWithCandies(t *testing.T) {
	gen := core.TestSuite[KidsWithCandies]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([]int{2,3,5,1,3}).Param(3).Result([]bool{true,true,true,false,true})
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{4,2,1,1,2}).Param(1).Result([]bool{true,false,false,false,false})
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{12,1,12}).Param(10).Result([]bool{true,false,true})
	}).Run(t)
}

func (KidsWithCandies) Solution(candies []int, extraCandies int) []bool {
    maxCandies := 0
	for _, v := range candies {
		if v > maxCandies {
            maxCandies = v
        }
	}

	result := make([]bool, len(candies))
	for i, _ := range candies {
		result[i] = candies[i] + extraCandies >= maxCandies
	}

	return result
}
