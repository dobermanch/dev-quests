from game import *


def main():
    game = TicTackToe()

    player1 = Player("Player 1", "X")
    player2 = Player("Player 2", "0")

    game.start_game(player1, player2)

    game.make_move(player2, 0, 0) # wrong move

    game.make_move(player1, 1, 1)
    game.make_move(player2, 1, 1) # wrong move
    game.make_move(player2, 0, 1)
    game.make_move(player1, 2, 0)
    game.make_move(player2, 0, 2)
    game.make_move(player1, 0, 0)
    game.make_move(player2, 1, 0)
    game.make_move(player1, 2, 2)

    status = game.get_status()
    if status.state == GameState.GAME_ENDED:
        if status.winner:
            score = game.get_player_score(status.winner)
            print(f"The '{status.winner.name}' player won the game. The players score is {score.score}.")

        if status.is_draw:
            print(f"The game has ended with draw")

        print("The game ended")

    scores = game.get_score_board()
    for score in scores:
        print(f"{score.player}: {score.score}")

if __name__ == "__main__":
    main()
