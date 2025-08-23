// https://leetcode.com/problems/summary-ranges

pub fn solution(nums: Vec<i32>) -> Vec<String> {
    let mut result = Vec::new();
    let mut start_at = 0;
    let length = nums.len();
    for i in 0..length {
        if i == length - 1 || nums[i] + 1 < nums[i + 1] {
            result.push(if i == start_at {
                nums[start_at].to_string()
            } else {
                format!("{}->{}", nums[start_at], nums[i])
            });

            start_at = i + 1;
        }
    }

    result
}