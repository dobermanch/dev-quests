// https://leetcode.com/problems/best-time-to-buy-and-sell-stock/

package problems

import "testing"

func TestMaxProfit(t *testing.T) {
	result := MaxProfit([]int{7, 1, 5, 3, 6, 4})
	t.Log(result)
}

func MaxProfit(prices []int) int {
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
