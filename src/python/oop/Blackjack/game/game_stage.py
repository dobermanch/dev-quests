from enum import IntEnum


class GameStage(IntEnum):
    ROUND_STARTED = 1
    BET_COMPLETED = 2
    INITIAL_CARDS_DRAWN = 3
    ROUND_ENDED = 4
