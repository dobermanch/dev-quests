from dataclasses import dataclass
from enum import IntEnum, Enum
import random

class Suits(IntEnum):
    HEARTS = 1
    SPADES = 2
    CLUBS = 3
    DIAMONDS = 4

class Ranks(Enum):
    ACE = [1, 11]
    TWO = [2]
    THREE = [3]
    FOUR = [4]
    FIVE = [5]
    SIX = [6]
    SEVEN = [7]
    EIGHT = [8]
    NINE = [9]
    TEN = [10]
    JACK = [10]
    QUEEN = [10]
    KING = [10]

@dataclass
class Card:
    rank: Ranks
    suit: Suits

class Deck:
    def __init__(self):
        self._cards: list[Card] = []
        for suit in Suits:
            for rank in Ranks:
                self._cards.append(Card(rank, suit))

        self._card_index = 0

    @property
    def is_empty(self) -> bool:
        return self._card_index >= len(self._cards)

    def draw_card(self) -> Card:
        if self.is_empty:
            raise Exception("The deck is empty")

        card = self._cards[self._card_index]
        self._card_index += 1
        return card

    def shuffle(self) -> None:
        self._card_index = 0
        count = len(self._cards)
        for i in range(count):
            swap_index = random.randint(0, count - 1)

            temp = self._cards[i]
            self._cards[i] = self._cards[swap_index]
            self._cards[swap_index] = temp
