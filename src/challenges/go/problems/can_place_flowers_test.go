// https://leetcode.com/problems/can-place-flowers/

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type CanPlaceFlowers struct{}

func TestCanPlaceFlowers(t *testing.T) {
	gen := core.TestSuite[CanPlaceFlowers]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([]int{1, 0, 0, 0, 1}).Param(1).Result(true)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{1, 0, 0, 0, 1}).Param(2).Result(false)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{1, 0, 0, 0, 0}).Param(2).Result(true)
	}).Run(t)
}

func (CanPlaceFlowers) Solution(flowerbed []int, n int) bool {
	plot := 0
	left := n

	for left > 0 && plot < len(flowerbed) {
		if flowerbed[plot] == 1 {
			plot++
		} else if (plot == 0 || flowerbed[plot-1] == 0) &&
			(plot+1 >= len(flowerbed) || flowerbed[plot+1] == 0) {
			flowerbed[plot] = 1
			plot++
			left--
		}

		plot++
	}

	return left == 0
}
