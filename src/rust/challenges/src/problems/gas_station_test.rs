// https://leetcode.com/problems/gas-station

pub fn solution(gas: Vec<i32>, cost: Vec<i32>) -> i32 {
    let mut startAt = 0;
    let mut sum = 0;
    let mut total = 0;
    for i in 0..gas.len() {
        total += gas[i] - cost[i];
        sum += gas[i] - cost[i];

        if sum < 0 {
            sum = 0;
            startAt = i + 1;
        }
    }

    if total >= 0 { startAt as i32 } else { -1 }
}