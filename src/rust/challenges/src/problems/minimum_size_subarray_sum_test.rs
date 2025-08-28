// https://leetcode.com/problems/minimum-size-subarray-sum

pub fn solution(target: i32, nums: Vec<i32>) -> i32 {
    let mut result = std::i32::MAX;
    let mut left = 0;
    let mut right = 0;
    let mut sum = 0;
    while right < nums.len() || sum >= target {
        if sum >= target {
            result = result.min((right - left) as i32);
            sum -= nums[left];
            left += 1;
        } else {
            sum += nums[right];
            right += 1;
        }
    }

    if result == std::i32::MAX { 0 } else { result }
}