// https://leetcode.com/problems/best-time-to-buy-and-sell-stock

pub fn solution(prices: Vec<i32>) -> i32 {
    let mut buyDay = 0;
    let mut profit = 0;

    for i in 1..prices.len() {
        if prices[buyDay] > prices[i] {
            buyDay = i;
        } else {
            let temp = prices[i] - prices[buyDay];
            if temp > profit {
                profit = temp;
            }
        }
    }

    profit
}