from dataclasses import dataclass
from .player import Player
from .game_state import GameState

@dataclass
class GameStatus:
    state: GameState
    winner: Player
    is_draw: bool
