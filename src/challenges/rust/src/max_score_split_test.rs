// https://leetcode.com/problems/maximum-score-after-splitting-a-string

pub fn solution(s: String) -> i32 {
    let s = s.chars().collect::<Vec<char>>();
    let mut oneCount = 0;
    for i in 0..s.len() {
        if s[i] == '1' {
            oneCount += 1;
        }
    }

    let mut zeroCount = 0;
    let mut score = 0;
    for i in 0..(s.len() - 1) {
        if s[i] == '0' {
            zeroCount += 1;
        } else {
            oneCount -= 1;
        }

        score = score.max(zeroCount + oneCount);
    }

    score
}