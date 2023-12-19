// https://leetcode.com/problems/image-smoother

pub fn solution(img: Vec<Vec<i32>>) -> Vec<Vec<i32>> {
    let directions = vec![
        vec![-1, -1], vec![-1, 0], vec![-1, 1],
        vec![0, -1], vec![0, 0], vec![0, 1],
        vec![1, -1], vec![1, 0], vec![1, 1],
    ];

    let count = directions.len();
    let rows = img.len();
    let cols = img[0].len();
    let mut result = vec![vec![0; cols]; rows];

    for row in 0..rows {
        for col in 0..cols {
            let mut neighbors = 0;

            for i in 0..count {
                let y = row as i32 + directions[i][0];
                let x = col as i32 + directions[i][1];

                if y >= 0 && y < rows as i32 && x >= 0 && x < cols as i32 {
                    result[row][col] += img[y as usize][x as usize];
                    neighbors += 1;
                }
            }

            result[row][col] /= neighbors;
        }
    }

    result
}