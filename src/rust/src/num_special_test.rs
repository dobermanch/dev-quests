// https://leetcode.com/problems/special-positions-in-a-binary-matrix

pub fn solution(mat: Vec<Vec<i32>>) -> i32 {
    let mut result = 0;
    let mut row_map: Vec<i32> = vec![0; mat.len()];
    let mut col_map: Vec<i32> = vec![0; mat[0].len()];

    for row in 0..mat.len() {
        for col in 0..mat[0].len() {
            if mat[row][col] == 1 {
                row_map[row] += 1;
                col_map[col] += 1;
            }
        }
    }

    for row in 0..mat.len() {
        if row_map[row] != 1 {
            continue;
        }

        for col in 0..mat[0].len() {
            if mat[row][col] == 1 && col_map[col] == 1 {
                result += 1;
            }
        }
    }

    result
}