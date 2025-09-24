package main

import (
	"fmt"

	"github.com/dobermanch/dev-quests/tic-tac-toe/internal"
)

func main() {
	game := internal.New()

	player1 := internal.Player{Name: "PLayer 1", Symbol: 'X'}
	player2 := internal.Player{Name: "PLayer 2", Symbol: 'O'}

	game.StartGame(&player1, &player2)
	game.MakeMove(&player2, 0, 0) // wrong move

	game.MakeMove(&player1, 1, 1)
	game.MakeMove(&player2, 1, 1) // wrong move
	game.MakeMove(&player2, 0, 1)
	game.MakeMove(&player1, 2, 0)
	game.MakeMove(&player2, 0, 2)
	game.MakeMove(&player1, 0, 0)
	game.MakeMove(&player2, 1, 0)
	game.MakeMove(&player1, 2, 2)

	status := game.GetStatus()
	if status.State == internal.Ended {
		if status.Winner != nil {
			score, _ := game.GetPlayerScore(status.Winner)
			fmt.Printf("The %s player won the game. The player's score is %d\n", status.Winner.Name, score.Score)
		} else if status.IsDraw {
			fmt.Println("The game ended with draw")
		}
	}

	scores := game.GetScoreBoard()
	fmt.Println("Score Board:")
	for _, record := range scores {
		fmt.Printf("  %s: %d\n", record.Player, record.Score)
	}
}
