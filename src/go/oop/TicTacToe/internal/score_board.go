package internal

import (
	"fmt"
	"sort"
)

type ScoreBoard struct {
	records map[string]int
}

func NewScore() ScoreBoard {
	return ScoreBoard{
		records: map[string]int{},
	}
}

func (b *ScoreBoard) RecordWin(player Player) {
	if _, ok := b.records[player.Name]; !ok {
		b.records[player.Name] = 0
	}

	b.records[player.Name] += 1
}

func (b *ScoreBoard) RecordLoose(player Player) {
	if _, ok := b.records[player.Name]; !ok {
		b.records[player.Name] = 0
	}

	b.records[player.Name] -= 1
}

func (b *ScoreBoard) GetPlayerScore(player Player) (ScoreRecord, error) {
	if _, ok := b.records[player.Name]; !ok {
		return ScoreRecord{}, fmt.Errorf("score not for %s not found", player.Name)
	}

	score := b.records[player.Name]

	return ScoreRecord{
		Player: player.Name,
		Score:  score,
	}, nil
}

func (b *ScoreBoard) GetTopPlayers() []ScoreRecord {
	// Do it properly, sort on update not here

	scores := []ScoreRecord{}

	for player, score := range b.records {
		scores = append(scores, ScoreRecord{Player: player, Score: score})
	}

	sort.Slice(scores, func(i, j int) bool {
		return scores[i].Score > scores[j].Score
	})

	return scores
}
