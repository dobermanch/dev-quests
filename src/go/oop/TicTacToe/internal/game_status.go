package internal

type GameState int

var (
	Idle    GameState = 0
	Playing GameState = 1
	Ended   GameState = 2
)

type GameStatus struct {
	State  GameState
	Winner *Player
	IsDraw bool
}
