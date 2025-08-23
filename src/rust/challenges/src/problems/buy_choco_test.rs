// https://leetcode.com/problems/buy-two-chocolates

pub fn solution1(prices: Vec<i32>, money: i32) -> i32 {
    let mut result = -200;
    let mut cost = 0;
    for i in 0..prices.len() {
        result = result.max(cost - prices[i]);
        cost = cost.max(money - prices[i]);
    }

    if result < 0 { money } else { result }
}

pub fn solution2(prices: Vec<i32>, money: i32) -> i32 {
    let mut prices = prices;
        
    prices.sort();

    let cost = prices[0] + prices[1];
    if cost > money {
        money
    } else {
        money - cost
    }
}