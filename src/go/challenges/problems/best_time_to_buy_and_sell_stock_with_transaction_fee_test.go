// https://leetcode.com/problems/best-time-to-buy-and-sell-stock-with-transaction-fee/

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type MaxProfitFee struct{}

func TestMaxProfitFee(t *testing.T) {
	gen := core.TestSuite[MaxProfitFee]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([]int{1, 3, 2, 8, 4, 9}).Param(2).Result(8)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{1, 3, 7, 5, 10, 3}).Param(3).Result(6)
	}).Run(t)
}

func (MaxProfitFee) Solution(prices []int, fee int) int {
	max := func(left int, right int) int {
		if left > right {
			return left
		}
		return right
	}

	temp := -prices[0]
	profit := 0

	for i := 1; i < len(prices); i++ {

		temp = max(temp, profit-prices[i])
		profit = max(profit, temp+prices[i]-fee)
	}

	return profit
}
