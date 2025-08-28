// https://leetcode.com/problems/trapping-rain-water

pub fn solution(height: Vec<i32>) -> i32 {
    if height.len() == 1 {
        return 0
    }
    
    let mut left = 0;
    let mut right = height.len() - 1;
    let mut trap = 0;

    let mut maxL = 0;
    let mut maxR = 0;
    while left <= right {
        if maxL < maxR {
            if maxL - height[left] > 0 {
                trap += maxL - height[left];
            }

            maxL = maxL.max(height[left]);
            left += 1;
        } else {
            if maxR - height[right] > 0 {
                trap += maxR - height[right];
            }

            maxR = maxR.max(height[right]);
            right -= 1;
        }
    }

    trap
}