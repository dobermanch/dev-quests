// https://leetcode.com/problems/candy

pub fn solution(ratings: Vec<i32>) -> i32 {
    let mut result = 1;
    let mut increase = 0;
    let mut decrease = 0;
    let mut maxCandy = 0;

    for i in 1..ratings.len() {
        if ratings[i - 1] < ratings[i] {
            increase += 1;
            maxCandy = increase;
            result += increase + 1;
            decrease = 0;
        }
        else if ratings[i - 1] > ratings[i] {
            decrease += 1;
            result += decrease + (if maxCandy >= decrease { 0 } else { 1 });
            increase = 0;
        } else {
            result += 1;
            decrease = 0;
            maxCandy = 0;
            increase = 0;
        }
    }

    result
}