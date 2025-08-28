// https://leetcode.com/problems/best-time-to-buy-and-sell-stock-with-transaction-fee

pub fn solution(prices: Vec<i32>, fee: i32) -> i32 {
    let mut temp = -prices[0];
    let mut profit = 0;

    for i in 1..prices.len() {
        temp = temp.max(profit - prices[i]);
        profit = profit.max(temp + prices[i] - fee);
    }

    profit
}