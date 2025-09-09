from .hand import Hand

class Player:
    def __init__(self, name: str, balance: int):
        self._name = name
        self._balance = balance
        self._hand = Hand()

    @property
    def name(self) -> str:
        return self._name

    @property
    def balance(self) -> int:
        return self._balance

    def payout(self, value: int) -> int:
        self._balance += value

    def loose_bet(self, value: int) -> int:
        self._balance -= value

    @property
    def hand(self) -> Hand:
        return self._hand

    def is_bust(self) -> bool:
        return self._hand.hand_values[0] > 21 if len(self._hand.hand_values) > 0 else False

class Dealer(Player):
    def __init__(self):
        super().__init__("Dealer", 0)

    def is_bust(self) -> bool:
        return self._hand.hand_values[-1] > 21 if len(self._hand.hand_values) > 0 else False
