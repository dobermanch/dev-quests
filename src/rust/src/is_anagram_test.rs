// https://leetcode.com/problems/valid-anagram

pub fn solution(s: String, t: String) -> bool {
    if s.len() != t.len() {
        return false;
    }

    let sChars = s.as_bytes();
    let tChars = t.as_bytes();
    let mut map = [0; 26];
    for ch in 0..s.len() {
        map[sChars[ch] as usize - 97] += 1;
        map[tChars[ch] as usize - 97] -= 1;
    }

    map.iter().all(|c| *c == 0)
}