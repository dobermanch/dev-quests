// https://leetcode.com/problems/buy-two-chocolates

package problems

import (
	"math"
	"sort"
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type BuyChoco struct{}

func TestBuyChoco(t *testing.T) {
	gen := core.TestSuite[BuyChoco]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([]int{1, 2, 2}).Param(3).Result(0)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{3, 2, 3}).Param(3).Result(3)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{74, 31, 38, 24, 25, 24, 5}).Param(79).Result(50)
	}).Run(t)
}

func (BuyChoco) Solution1(prices []int, money int) int {
	max := func(left int, right int) int {
		if left > right {
			return left
		}
		return right
	}

	result := math.MinInt
	cost := 0
	for i := 0; i < len(prices); i++ {
		result = max(result, cost-prices[i])
		cost = max(cost, money-prices[i])
	}

	if result < 0 {
		return money
	}

	return result
}

func (BuyChoco) Solution2(prices []int, money int) int {
	sort.Ints(prices)

	cost := prices[0] + prices[1]
	if cost > money {
		return money
	}

	return money - cost
}
