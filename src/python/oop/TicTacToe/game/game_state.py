from enum import IntEnum


class GameState(IntEnum):
    IDLE = 1
    PLAYING = 2
    GAME_ENDED = 3
