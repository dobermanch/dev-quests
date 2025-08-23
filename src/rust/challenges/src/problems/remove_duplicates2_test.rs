// https://leetcode.com/problems/remove-duplicates-from-sorted-array-ii

pub fn solution(nums: &mut Vec<i32>) -> i32 {
    let mut left = 1;
    let mut count = 1;
    for right in 1..nums.len() {
        if nums[right] == nums[right - 1] {
            count += 1;
        } else {
            count = 1;
        }
        
        if count <= 2 {
            nums[left] = nums[right];
            left += 1;
        }
    }

    left as i32
}