// https://leetcode.com/problems/best-time-to-buy-and-sell-stock/

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type MaxProfit struct{}

func TestMaxProfit(t *testing.T) {
	gen := core.TestSuite[MaxProfit]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([]int{7, 1, 5, 3, 6, 4}).Result(5)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{7, 6, 4, 3, 1}).Result(0)
	}).Run(t)
}

func (MaxProfit) Solution(prices []int) int {
	buyDay := 0
	profit := 0

	for i := 0; i < len(prices); i++ {
		if prices[buyDay] > prices[i] {
			buyDay = i
		} else {
			temp := prices[i] - prices[buyDay]
			if temp > profit {
				profit = temp
			}
		}
	}

	return profit
}
