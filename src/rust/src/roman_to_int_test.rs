// https://leetcode.com/problems/roman-to-integer
use std::collections::HashMap;

pub fn solution(s: String) -> i32 {
    let chars = s.chars().collect::<Vec<char>>();
    let mut set = HashMap::new();
    set.insert('I', 1);
    set.insert('V', 5);
    set.insert('L', 50);
    set.insert('X', 10);
    set.insert('C', 100);
    set.insert('D', 500);
    set.insert('M', 1000);

    let mut result = 0;
    for i in 0..s.len() {
        if i + 1 < chars.len() && set.get(&chars[i]) < set.get(&chars[i + 1]) {
            result -= set.get(&chars[i]).unwrap();
        } else {
            result += set.get(&chars[i]).unwrap();
        }
    }

    result
}