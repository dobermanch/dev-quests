from .score_record import ScoreRecord
from .player import Player


class ScoreBoard:
    def __init__(self):
        self._score = {}

    def record_win(self, player: Player):
        if player.name not in self._score:
            self._score[player.name] = 0

        self._score[player.name] += 1

    def record_loose(self, player: Player):
        if player.name not in self._score:
            self._score[player.name] = 0

        self._score[player.name] -= 1

    def get_player_score(self, player: Player) -> ScoreRecord:
        return ScoreRecord(player.name, self._score[player.name] if player.name in self._score else 0)

    def get_top_players(self) -> list[ScoreRecord]:
        top = []
        for player, score in self._score.items():
            top.append(ScoreRecord(player, score))

        return sorted(top, key=lambda x: -x.score)
