from .deck import Card

class Hand:
    def __init__(self):
        self._cards: list[Card] = []
        self._values = []

    @property
    def cards(self) -> list[Card]:
        return self._cards

    @property
    def hand_values(self) -> list[int]:
        return self._values

    def clear(self):
        self._cards = []
        self._values = []

    def add_card(self, card: Card):
        self._cards.append(card)

        if len(self._values) <= 0:
            for rank in card.rank.value:
                self._values.append(rank)
        else:
            values = []
            for value in self._values:
                for rank in card.rank.value:
                    values.append(rank + value)

            self._values = sorted(values)
