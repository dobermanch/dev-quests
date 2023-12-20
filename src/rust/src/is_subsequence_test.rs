// https://leetcode.com/problems/is-subsequence

pub fn solution(s: String, t: String) -> bool {
    let s = s.chars().collect::<Vec<char>>();
    let t = t.chars().collect::<Vec<char>>();

    if s.len() == 0 {
        return true;
    }

    if t.len() == 0 {
        return false;
    }

    let mut j = 0;
    for i in 0..t.len() {
        if t[i] == s[j] {
            j += 1;
            if j >= s.len() {
                break;
            }
        }
    }

    j == s.len()
}