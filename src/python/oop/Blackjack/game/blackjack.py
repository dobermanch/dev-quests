from .deck import Deck
from .game_stage import GameStage
from .player import Player, Dealer
from .player_action import PlayerAction
from .round_state import RoundState

class Blackjack:
    def __init__(self, players: list[Player]):
        self._deck = Deck()
        self._deck.shuffle()

        self._players = players
        self._players_by_name = {p.name: p for p in players}
        self._dealer = Dealer()

        self._round_sate = RoundState()
        self._stage = GameStage.ROUND_STARTED

    def start_round(self):
        for player in self._players:
            player.hand.clear()

        self._dealer.hand.clear()

        self._deck.shuffle()

        self._round_sate = RoundState()
        self._stage = GameStage.ROUND_STARTED

    def bet(self, player: Player, bet: int):
        if self._stage != GameStage.ROUND_STARTED:
            raise Exception("Round is not started")

        if player.name in self._round_sate.bets:
            raise Exception(f"{player.name} already bet")

        self._round_sate.bets[player.name] = bet
        print(f"{player.name} bet: {bet}")

        if len(self._round_sate.bets) == len(self._players):
            self._stage = GameStage.BET_COMPLETED
            self._deal_initial_cards()

    def stand(self, player: Player) -> None:
        if self._stage != GameStage.INITIAL_CARDS_DRAWN:
            raise Exception("Players did not get cards yet")

        if player.name in self._round_sate.actions and self._round_sate.actions[player.name] == PlayerAction.STAND:
            raise Exception(f"{player.name} already completed the turn")

        if player.is_bust():
            raise Exception(f"{player.name} is already busted")

        self._round_sate.actions[player.name] = PlayerAction.STAND
        print(f"{player.name} stand")

        if len(self._round_sate.actions) == len(self._players):
            self._dealer_turn()

    def hit(self, player: Player) -> None:
        if self._stage != GameStage.INITIAL_CARDS_DRAWN:
            raise Exception("Players did not get cards yet")

        if player.name in self._round_sate.actions and self._round_sate.actions[player.name] == PlayerAction.STAND:
            raise Exception(f"{player.name} is already stand")

        if player.is_bust():
            raise Exception(f"{player.name} is already busted")

        card = self._deck.draw_card()
        player.hand.add_card(card)
        self._round_sate.actions[player.name] = PlayerAction.HIT
        print(f"{player.name} hit {card.rank.name} of {card.suit.name}")

        if len(self._round_sate.actions) == len(self._players):
            self._dealer_turn()

    def next_player(self) -> Player:
        if self._stage == GameStage.ROUND_STARTED:
            for name, player in self._players_by_name.items():
                if name not in self._round_sate.bets:
                    return player

            return None

        if self._stage == GameStage.INITIAL_CARDS_DRAWN:
            for name, player in self._players_by_name.items():
                if not player.is_bust() and player.name not in self._round_sate.actions or self._round_sate.actions[player.name] != PlayerAction.STAND:
                    return player

        return None

    def _deal_initial_cards(self) -> None:
        if self._stage != GameStage.BET_COMPLETED:
            raise Exception("Players did not bet yet")

        for _ in range(2):
            for player in self._players:
                player.hand.add_card(self._deck.draw_card())

            self._dealer.hand.add_card(self._deck.draw_card())

        self._check_initial_winner()

        self._stage = GameStage.INITIAL_CARDS_DRAWN

    def _check_initial_winner(self) -> None:
        for player in self._players:
            for value in player.hand.hand_values:
                if value == 21:
                    self._round_sate.initial_winners = True
                    break

    def _dealer_turn(self):
        while self._dealer.hand.hand_values[-1] < 17:
            self._dealer.hand.add_card(self._deck.draw_card())

        print(f"{self._dealer.name}:")
        for card in self._dealer.hand.cards:
            print(f"   {card.rank.name} {card.suit.name}")

        self._complete_round()

    def _complete_round(self):
        dealer_hand = self._dealer.hand.hand_values[-1]
        dealer_busted = self._dealer.is_bust()

        for player in self._players:
            if player.name in self._round_sate.initial_winners:
                player.payout(self._round_sate.bets[player.name] * 1.5)
                print(f"{player.name} payed out, new balance {player.balance}")
            elif player.is_bust():
                player.loose_bet(self._round_sate.bets[player.name])
                print(f"{player.name} loose, new balance {player.balance}")
            elif dealer_busted or player.hand.hand_values[-1] > dealer_hand:
                player.payout(self._round_sate.bets[player.name] * 2)
                print(f"{player.name} payed out, new balance {player.balance}")
            else:
                player.loose_bet(self._round_sate.bets[player.name])
                print(f"{player.name} loose, new balance {player.balance}")

        self._stage = GameStage.ROUND_ENDED

        self.start_round()
