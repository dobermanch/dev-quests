
from game import *

def main():
    player1 = Player("Player 1", 100)
    player2 = Player("Player 2", 100)

    game = Blackjack([player1, player2])

    player = game.next_player()
    game.bet(player, 10)

    player = game.next_player()
    game.bet(player, 10)

    for player in [player1, player2]:
        print(f"{player.name}:")
        for card in player.hand.cards:
            print(f"   {card.rank.name} {card.suit.name}")

    player = game.next_player()
    if not player.is_bust():
        game.hit(player)
    if not player.is_bust():
        game.stand(player)

    player = game.next_player()
    if not player.is_bust():
        game.stand(player)

if __name__ == "__main__":
    main()
