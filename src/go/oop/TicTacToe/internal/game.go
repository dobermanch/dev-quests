package internal

import "fmt"

type Game struct {
	board              *Board
	scoreBoard         *ScoreBoard
	currentPlayerIndex int
	players            []*Player
	status             GameStatus
}

func New() Game {
	board := NewBoard()
	scoreBoard := NewScore()
	return Game{
		board:      &board,
		scoreBoard: &scoreBoard,
		status: GameStatus{
			State: Idle,
		},
	}
}

func (g *Game) StartGame(player1, player2 *Player) {
	if g.status.State == Playing {
		fmt.Println("Stop or finish game before stating new one")
		return
	}

	fmt.Println("Start new game")
	fmt.Printf("   Player 1: %s\n", player1.Name)
	fmt.Printf("   Player 2: %s\n", player2.Name)

	board := NewBoard()
	g.board = &board
	g.players = []*Player{player1, player2}
	g.currentPlayerIndex = 0
	g.status = GameStatus{State: Playing}

	fmt.Println("")
	fmt.Println("Moves:")
}

func (g *Game) EndGame(player1, player2 *Player) {
	if g.status.State != Playing {
		return
	}

	fmt.Println("Game stopped")
	g.status = GameStatus{State: Ended}
}

func (g *Game) MakeMove(player *Player, x, y int) {
	if g.status.State != Playing {
		fmt.Println("Game is not started yet")
		return
	}

	if player.Name != g.players[g.currentPlayerIndex].Name {
		fmt.Printf("wrong player, the '%s' player should be moving\n", g.players[g.currentPlayerIndex].Name)
		return
	}

	err := g.board.Update(player.Symbol, x, y)
	if err != nil {
		fmt.Println(err)
		return
	}

	fmt.Printf("  %s: [x: %d, y: %d, s: %c]\n", player.Name, x, y, player.Symbol)

	if g.board.IsWinner(player.Symbol, x, y) {
		g.scoreBoard.RecordWin(*player)

		index := g.getNextPlayer(g.currentPlayerIndex)
		for index != g.currentPlayerIndex {
			g.scoreBoard.RecordLoose(*g.players[index])
			index = g.getNextPlayer(index)
		}

		g.status = GameStatus{State: Ended, Winner: player}
		return
	}

	if g.board.IsDraw() {
		g.status = GameStatus{State: Ended, IsDraw: true}
		return
	}

	g.currentPlayerIndex = g.getNextPlayer(g.currentPlayerIndex)
}

func (g *Game) GetStatus() GameStatus {
	return g.status
}

func (g *Game) GetPlayerScore(player *Player) (ScoreRecord, error) {
	return g.scoreBoard.GetPlayerScore(*player)
}

func (g *Game) GetScoreBoard() []ScoreRecord {
	return g.scoreBoard.GetTopPlayers()
}

func (g *Game) getNextPlayer(index int) int {
	return (index + 1) % len(g.players)
}
