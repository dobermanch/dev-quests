// https://leetcode.com/problems/majority-element/

pub fn solution(nums: Vec<i32>) -> i32 {
    let mut result = 0;
    let mut count = 0;

    for num in nums {
        if count == 0 {
            result = num;
        }

        if result == num {
            count += 1;
        } else {
            count -= 1;
        }
    }

    result
}