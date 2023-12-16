// https://leetcode.com/problems/n-queens-ii

pub fn solution(n: i32) -> i32 {
    fn placeQueens(row: i32, n: i32, mut leftDiagMap: i32, mut rightDiagMap: i32, mut colMap: i32) -> i32 {
        if row >= n {
            return 1;
        }

        let mut result = 0;
        for col in 0..n {
            let leftDiagShift = row + col;
            let rightDiagShift = n + (row - col);

            if (colMap & 1 << col) != 0
                || (leftDiagMap & 1 << leftDiagShift) != 0
                || (rightDiagMap & 1 << rightDiagShift) != 0 {
                continue;
            }

            colMap |= 1 << col;
            leftDiagMap |= 1 << leftDiagShift;
            rightDiagMap |= 1 << rightDiagShift;

            result += placeQueens(row + 1, n, leftDiagMap, rightDiagMap, colMap);

            colMap &= !(1 << col);
            leftDiagMap &= !(1 << leftDiagShift);
            rightDiagMap &= !(1 << rightDiagShift);
        }

        result
    }

    placeQueens(0, n, 0, 0, 0)
}