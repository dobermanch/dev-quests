// https://leetcode.com/problems/game-of-life

pub fn solution1(board: &mut Vec<Vec<i32>>) -> Vec<Vec<i32>> {
    let directions = vec![
        vec![-1, -1], vec![-1, 0], vec![-1, 1],
        vec![0, -1], vec![0, 1],
        vec![1, -1], vec![1, 0], vec![1, 1],
    ];

    let count = directions.len();
    let rows = board.len();
    let cols = board[0].len();

    for row in 0..rows {
        for col in 0..cols {
            let mut neighbors = 0;

            for i in 0..count {
                let y = row as i32 + directions[i][0];
                let x = col as i32 + directions[i][1];

                if y >= 0 && y < rows as i32 && x >= 0 && x < cols as i32 &&
                    (board[y as usize][x as usize] == 1 || board[y as usize][x as usize] >= 20) {
                    neighbors += 1;
                }
            }

            if board[row][col] == 0 {
                board[row][col] = neighbors + 10;
            } else {
                board[row][col] = neighbors + 20;
            }
        }
    }

    for row in 0..rows {
        for col in 0..cols {
            let mut neighbors = 0;
            if board[row][col] >= 20 {
                neighbors = board[row][col] - 20;
            } else {
                neighbors = board[row][col] - 10;
            }

            if neighbors < 2 || neighbors > 3 {
                board[row][col] = 0;
            } else if neighbors == 3 && board[row][col] < 20 {
                board[row][col] = 1;
            } else if board[row][col] >= 20 {
                board[row][col] = 1;
            } else {
                board[row][col] = 0;
            }
        }
    }

    board
}