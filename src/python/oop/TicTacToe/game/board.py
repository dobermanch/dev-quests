class Board:
    def __init__(self):
        self._size = 3
        self._cells = [["" for _ in range(self._size)] for _ in range(self._size)]
        self._winning_length = self._size
        self._left_moves = self._size * self._size

    def update_board(self, symbol, x: int, y: int):
        if x < 0 or x >= self._size or y < 0 or y >= self._size:
            raise ValueError(f"The x:{x}, y:{y} outside of the game board")

        if self._cells[x][y] != "":
            raise Exception(f"The x:{x}, y:{y} cell already contains '{self._cells[x][y]}'.")

        self._cells[x][y] = symbol
        self._left_moves -= 1

    def is_draw(self) -> bool:
        return self._left_moves <= 0

    def is_winner(self, symbol: str, x: int, y: int) -> bool:
        count_x = 0
        count_y = 0
        diag_l = 0
        diag_r = 0

        for i in range(self._size):
            if self._cells[x][i] == symbol:
                count_x += 1
            if self._cells[i][y] == symbol:
                count_y += 1

            if self._cells[i][i] == symbol:
                diag_l += 1

            d = self._size - i - 1
            if self._cells[d][i] == symbol:
                diag_r += 1

        if count_x == self._winning_length or count_y == self._winning_length \
           or diag_l == self._winning_length or diag_r == self._winning_length:
            return True

        return False
