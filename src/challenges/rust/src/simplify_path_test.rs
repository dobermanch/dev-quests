// https://leetcode.com/problems/simplify-path
use std::collections::LinkedList;

pub fn solution(prices: Vec<i32>, money: i32) -> i32 {
    let path = path.chars().collect::<Vec<char>>();
    let mut stack = LinkedList::new();
    let mut segment = String::new();

    for i in 0..path.len() {
        if path[i] != '/' {
            segment.push(path[i]);
        }

        if path[i] == '/' || i == path.len() - 1 {
            let dir = segment.clone();

            if dir == ".." && stack.len() > 0 {
                stack.pop_back();
            } else if dir.len() > 0 && dir != "." && dir != ".." {
                stack.push_back(dir);
            }

            segment.clear();
        }
    }

    let mut builder = String::new();
    if stack.len() <= 0 {
        builder.push('/');
    }
    
    for sub in stack.iter().rev() {
        builder.insert_str(0, &format!("/{}", sub));
    }

    builder
}