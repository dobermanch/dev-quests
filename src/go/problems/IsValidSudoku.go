// https://leetcode.com/problems/valid-sudoku/

package problems

func IsValidSudoku(board [][]byte) bool {
	rows := len(board)
	cols := len(board[0])

	rowsMasks := [9]int{}
	colsMasks := [9]int{}
	boxMasks := [3][3]int{}

	for i := 0; i < rows; i++ {
		for j := 0; j < cols; j++ {
			if board[i][j] == '.' {
				continue
			}

			mask := 1 << board[i][j]
			if boxMasks[i/3][j/3]&mask != 0 {
				return false
			}
			boxMasks[i/3][j/3] |= mask

			if rowsMasks[i]&mask != 0 {
				return false
			}
			rowsMasks[i] |= mask

			if colsMasks[j]&mask != 0 {
				return false
			}
			colsMasks[j] |= mask
		}
	}

	return true
}
