// https://leetcode.com/problems/valid-palindrome

pub fn solution(s: String) -> bool {
    let mut left = 0;
    let mut right = s.len() - 1;
    let s = s.chars().collect::<Vec<char>>();

    while left < right {
        let l_rune = s[left];
        let r_rune = s[right];

        if !l_rune.is_ascii_alphanumeric() {
            left += 1;
            continue;
        }

        if !r_rune.is_ascii_alphanumeric() {
            right -= 1;
            continue;
        }

        if l_rune.to_ascii_lowercase() != r_rune.to_ascii_lowercase() {
            return false;
        }

        left += 1;
        right -= 1;
    }

    true
}