// https://leetcode.com/problems/largest-3-same-digit-number-in-string

pub fn solution(num: String) -> String {
    let mut result = '\0';
    let mut digit = '\0';
    let mut count = 0;

    for ch in num.chars() {
        if ch != digit {
            digit = ch;
            count = 1;
            continue
        }

        count += 1;
        if count >= 3 && digit > result {
            result = digit;
        }
    }

    if result == '\0' { 
        String::from("") 
    } else { 
        format!("{}{}{}", result, result, result)
    }
}