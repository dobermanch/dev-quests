package operands

import (
	"github.com/dobermanch/dev-quests/file-search/internal/models"
	"github.com/dobermanch/dev-quests/file-search/internal/predicates"
)

type NotOperand struct {
	predicate predicates.Predicate
}

func Not(predicate predicates.Predicate) predicates.Predicate {
	return &NotOperand{
		predicate: predicate,
	}
}

func (o *NotOperand) Match(file *models.FileInfo) bool {
	return !o.predicate.Match(file)
}
