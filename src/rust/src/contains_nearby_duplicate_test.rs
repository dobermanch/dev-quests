// https://leetcode.com/problems/contains-duplicate-ii
use std::collections::HashMap;

pub fn solution(prices: Vec<i32>, money: i32) -> i32 {
    let mut map = HashMap::new();

    for (i, &num) in nums.iter().enumerate() {
        if map.contains_key(&num) && i as i32 - map[&num] <= k {
            return true;
        }

        map.insert(num, i as i32);
    }

    false
}