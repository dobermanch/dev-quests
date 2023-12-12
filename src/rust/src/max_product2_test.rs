// https://leetcode.com/problems/maximum-product-of-two-elements-in-an-array

pub fn solution(nums: Vec<i32>) -> bool {
    let mut num1 = 0;
    let mut num2 = 0;
    for i in 0..nums.len() {
        if nums[i] > num1 {
            num2 = num1;
            num1 = nums[i];
        } else if nums[i] > num2 {
            num2 = nums[i];
        }
    }

    (num1 - 1) * (num2 - 1)
}