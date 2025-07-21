// https://leetcode.com/problems/basic-calculator

pub fn solution(s: String) -> i32 {
    let chars = s.chars().collect::<Vec<char>>();
    let mut numbers = vec![];
    let mut operand = 1;
    let mut number = 0;
    let mut result = 0;

    for i in 0..chars.len() {
        if chars[i] >= '0' {
            number *= 10;
            number += chars[i] as i32 - 48;
        }

        if chars[i] < '0' || i == chars.len() - 1 {
            result += number * operand;
            number = 0;
        }

        if chars[i] == '(' {
            numbers.push(result);
            numbers.push(operand);
            operand = 1;
            result = 0;
        } else if chars[i] == ')' {
            result *= numbers.pop().unwrap();
            result += numbers.pop().unwrap();
        } else if chars[i] == '-' {
            operand = -1;
        } else if chars[i] == '+' {
            operand = 1;
        }
    }

    result
}