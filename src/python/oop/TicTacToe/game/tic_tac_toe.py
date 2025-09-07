from .board import Board
from .game_state import GameState
from .game_status import GameStatus
from .player import Player
from .score_board import ScoreBoard
from .score_record import ScoreRecord

class TicTackToe:
    def __init__(self):
        self._board = Board()
        self._players: list[Player] = []
        self._score_board = ScoreBoard()
        self._status = GameStatus(GameState.IDLE, None, False)

    def start_game(self, player1: Player, player2: Player) -> None:
        if self._status.state == GameState.PLAYING:
            print("The game in progress")
            return

        self._board = Board()
        self._players: list[Player] = []
        self._players.append(player1)
        self._players.append(player2)
        self._current_player = player1
        self._status = GameStatus(GameState.PLAYING, None, False)

    def make_move(self, player: Player, x: int, y: int) -> None:
        if self._status.state != GameState.PLAYING:
            print("Start new game to continue")
            return

        if player != self._current_player:
            print(f"Wrong player. The '{self._current_player.name}' player should make a move")
            return

        try:
            self._board.update_board(player.symbol, x, y)
        except Exception as ex:
            print(str(ex))
            return

        if self._board.is_winner(player.symbol, x, y):
            self._score_board.record_loose(self._get_next_player(player))
            self._score_board.record_win(player)

            self._status = GameStatus(GameState.GAME_ENDED, player, False)
            return

        if self._board.is_draw():
            self._status = GameStatus(GameState.GAME_ENDED, None, True)
            return

        self._current_player = self._get_next_player(player)

    def get_status(self) -> GameStatus:
        return self._status

    def get_player_score(self, player: Player) -> ScoreRecord:
        return self._score_board.get_player_score(player)

    def get_score_board(self) -> list[ScoreRecord]:
        return self._score_board.get_top_players()

    def _get_next_player(self, player: Player) -> Player:
        for next_player in self._players:
            if next_player != player:
                return next_player
