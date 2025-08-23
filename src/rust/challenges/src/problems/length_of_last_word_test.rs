// https://leetcode.com/problems/length-of-last-word

pub fn solution(s: String) -> i32 {
    let chars = s.chars().collect::<Vec<char>>();
    let mut startAt = -1;
    let mut endAt = -1;
    for i in (0..chars.len()).rev() {
        if startAt == -1 && chars[i] >= 'A' {
            startAt = i as i32;
        }
        else if startAt != -1 && chars[i] == ' ' {
            endAt = i as i32;
            break;
        }
    }

    startAt - endAt
}