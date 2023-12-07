// https://leetcode.com/problems/largest-odd-number-in-string

pub fn solution(num: String) -> String {
    let chars = num.as_bytes();
    for i in (0..num.len()).rev()  {
        if chars[i] % 2 != 0 {
            return String::from(&num[0..i + 1]);
        }
    }

    "".to_string()
}