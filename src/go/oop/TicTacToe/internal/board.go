package internal

import (
	"fmt"
)

type Board struct {
	Size int
	Grid [][]*rune

	winingLength int
	leftMoves    int
}

func NewBoard() Board {
	size := 3

	grid := make([][]*rune, size)
	for i := 0; i < size; i++ {
		grid[i] = make([]*rune, size)
	}

	return Board{
		Size:         size,
		Grid:         grid,
		winingLength: size,
		leftMoves:    size * size,
	}
}

func (b *Board) IsDraw() bool {
	return b.leftMoves <= 0
}

func (b *Board) Update(symbol rune, x, y int) error {
	if x < 0 || x >= b.Size || y < 0 || y >= b.Size {
		return fmt.Errorf("the [x:%d, y:%d] outsize of the game board", x, y)
	}

	if b.Grid[x][y] != nil {
		return fmt.Errorf("the [x:%d, y:%d] already contains '%c'", x, y, *b.Grid[x][y])
	}

	b.Grid[x][y] = &symbol
	b.leftMoves -= 1

	return nil
}

func (b *Board) IsWinner(symbol rune, x, y int) bool {
	var count_x, count_y, diag_l, diag_r int

	for i := 0; i < b.Size; i++ {
		if b.Grid[x][i] != nil && *b.Grid[x][i] == symbol {
			count_x += 1
		}

		if b.Grid[i][y] != nil && *b.Grid[i][y] == symbol {
			count_y += 1
		}

		if b.Grid[i][i] != nil && *b.Grid[i][i] == symbol {
			diag_l += 1
		}

		d := b.Size - i - 1
		if b.Grid[d][i] != nil && *b.Grid[d][i] == symbol {
			diag_r += 1
		}
	}

	if count_x == b.winingLength || count_y == b.winingLength ||
		diag_l == b.winingLength || diag_r == b.winingLength {
		return true
	}

	return false
}
