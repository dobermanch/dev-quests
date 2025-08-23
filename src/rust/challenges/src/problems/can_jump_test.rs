// https://leetcode.com/problems/jump-game

pub fn solution(nums: Vec<i32>) -> bool {
    let mut jumpTo = nums.len() - 1;
    for i in (0..nums.len() - 1).rev() {
        let temp = i + nums[i] as usize;
        if temp >= jumpTo {
            jumpTo = i;
        }
    }

    jumpTo == 0
}