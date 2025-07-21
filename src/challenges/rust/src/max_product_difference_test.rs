// https://leetcode.com/problems/maximum-product-difference-between-two-pairs

pub fn solution1(nums: Vec<i32>) -> i32 {
    let mut min1 = std::i32::MAX;
    let mut min2 = std::i32::MAX;
    let mut max1 = 0;
    let mut max2 = 0;

    for i in 0..nums.len() {
        if nums[i] > max1 {
            max2 = max1;
            max1 = nums[i];
        } else if nums[i] > max2 {
            max2 = nums[i];
        }

        if nums[i] < min1 {
            min2 = min1;
            min1 = nums[i];
        } else if nums[i] < min2 {
            min2 = nums[i];
        }
    }

    max1 * max2 - min1 * min2
}

pub fn solution2(nums: Vec<i32>) -> i32 {
    let mut nums = nums;
    nums.sort();
    let len = nums.len();
    nums[len - 2] * nums[len - 1] - nums[0] * nums[1]
}