// https://leetcode.com/problems/destination-city
use std::collections::HashSet;
pub fn solution(paths: Vec<Vec<String>>) -> String {
    let mut from = HashSet::new();
    for path in &paths {
        from.insert(&path[0]);
    }

    for path in &paths {
        if !from.contains(&path[1]) {
            return path[1].to_string()
        }
    }

    "".to_string()
}