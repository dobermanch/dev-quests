// https://leetcode.com/problems/calculate-money-in-leetcode-bank

pub fn solution(n: i32) -> i32 {
    let mut week = 0;
    let mut result = 0;
    for i in 0..n {
        let day = i % 7;
        if day == 0 {
            week += 1;
        }

        result += week + day;
    }

    result
}