package operands

import (
	"github.com/dobermanch/dev-quests/file-search/internal/models"
	"github.com/dobermanch/dev-quests/file-search/internal/predicates"
)

type AndOperand struct {
	predicates []predicates.Predicate
}

func And(predicates []predicates.Predicate) predicates.Predicate {
	return &AndOperand{
		predicates: predicates,
	}
}

func (o *AndOperand) Match(file *models.FileInfo) bool {
	for _, predicate := range o.predicates {
		if !predicate.Match(file) {
			return false
		}
	}

	return true
}
