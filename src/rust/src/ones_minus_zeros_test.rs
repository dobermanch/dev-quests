// https://leetcode.com/problems/difference-between-ones-and-zeros-in-row-and-column

pub fn solution(grid: Vec<Vec<i32>>) -> Vec<Vec<i32>> {
    let rows = grid.len();
    let cols = grid[0].len();
    let mut row_map: Vec<i32> = vec![0; rows];
    let mut col_map: Vec<i32> = vec![0; cols];

    for row in 0..rows {
        for col in 0..cols {
            if grid[row][col] == 1 {
                row_map[row] += 1;
                col_map[col] += 1;
            }
        }
    }

    let mut result: Vec<Vec<i32>> = vec![vec![0; cols]; rows];
    for row in 0..rows {
        for col in 0..cols {
            result[row][col] = row_map[row] + col_map[col] - (rows as i32 - row_map[row]) - (cols as i32 - col_map[col]);
        }
    }

    result
}