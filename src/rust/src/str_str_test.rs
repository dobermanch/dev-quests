// https://leetcode.com/problems/find-the-index-of-the-first-occurrence-in-a-string

pub fn solution(haystack: String, needle: String) -> i32 {
    if haystack.len() < needle.len() {
        return -1;
    }
    
    let haystack = haystack.chars().collect::<Vec<char>>();
    let needle = needle.chars().collect::<Vec<char>>();

    let length = haystack.len() - needle.len() + 1;
    for index in 0..length { 
        if haystack[index] != needle[0] {
            continue;
        }

        let mut left = 0;
        let mut right = needle.len() - 1;
        while left <= right 
                && haystack[index + left] == needle[left]
                && haystack[index + right] == needle[right] {
            left += 1;
            right = right.saturating_sub(1);
        }

        if left > right {
            return index as i32;
        }
    }

    -1
}