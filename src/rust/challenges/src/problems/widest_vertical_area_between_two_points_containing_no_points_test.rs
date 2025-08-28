// https://leetcode.com/problems/widest-vertical-area-between-two-points-containing-no-points

pub fn solution1(points: Vec<Vec<i32>>) -> i32 {
    let mut points = points;
    points.sort_unstable_by_key(|point| point[0]);

    let mut max_diff = 0;
    for i in 1..points.len() {
        let diff = points[i][0] - points[i - 1][0];
        if diff > max_diff {
            max_diff = diff;
        }
    }

    max_diff
}