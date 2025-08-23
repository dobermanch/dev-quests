// https://leetcode.com/problems/best-time-to-buy-and-sell-stock-ii

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type MaxProfit2 struct{}

func TestMaxProfit2(t *testing.T) {
	gen := core.TestSuite[MaxProfit2]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([]int{7, 1, 5, 3, 6, 4}).Result(7)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{1, 2, 3, 4, 5}).Result(4)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{7, 6, 4, 3, 1}).Result(0)
	}).Run(t)
}

func (MaxProfit2) Solution(prices []int) int {
	profit := 0

	for i := 1; i < len(prices); i++ {
		if prices[i] > prices[i-1] {
			profit += prices[i] - prices[i-1]
		}
	}

	return profit
}
