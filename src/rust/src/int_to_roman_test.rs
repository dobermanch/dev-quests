// https://leetcode.com/problems/integer-to-roman
use std::collections::HashMap;

pub fn solution(num: i32) -> String {
    let mut map = HashMap::new();
    map.insert(1, "I");
    map.insert(5, "V");
    map.insert(10, "X");
    map.insert(50, "L");
    map.insert(100, "C");
    map.insert(500, "D");
    map.insert(1000, "M");

    let mut result = String::new();
    let mut acc = 1;
    let mut num = num;
    while num > 0 {
        let reminder = num % 10;
        let number = reminder * acc;
        num /= 10;

        result = match reminder {
            0..=3 => map[&acc].repeat(reminder as usize) + &result,
            4 => map[&acc].to_owned() + map[&(number + acc)] + &result,
            5..=8 => map[&(5 * acc)].to_owned() + &map[&acc].repeat((reminder - 5) as usize) + &result,
            9 => map[&acc].to_owned() + map[&(acc * 10)] + &result,
            _ => map[&number].to_owned() + &result,
        };

        acc *= 10;
    }

    result
}