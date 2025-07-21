// https://leetcode.com/problems/remove-element

pub fn solution(nums: &mut Vec<i32>, val: i32) -> i32 {
    let mut left = 0;
    for right in 0..nums.len() {
        if nums[right] != val {
            nums[left] = nums[right];
            left += 1;
        }
    }

    left as i32
}