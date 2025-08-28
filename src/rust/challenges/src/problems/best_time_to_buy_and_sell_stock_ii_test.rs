// https://leetcode.com/problems/best-time-to-buy-and-sell-stock-ii

pub fn solution(prices: Vec<i32>) -> i32 {
    let mut profit = 0;

    for i in 1..prices.len() {
        if prices[i] > prices[i - 1] {
            profit += prices[i] - prices[i - 1];
        }
    }

    profit
}