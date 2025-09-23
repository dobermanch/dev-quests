package operands

import (
	"github.com/dobermanch/dev-quests/file-search/internal/models"
	"github.com/dobermanch/dev-quests/file-search/internal/predicates"
)

type OrOperand struct {
	predicates []predicates.Predicate
}

func Or(predicates []predicates.Predicate) predicates.Predicate {
	return &OrOperand{
		predicates: predicates,
	}
}

func (o *OrOperand) Match(file *models.FileInfo) bool {
	for _, predicate := range o.predicates {
		if predicate.Match(file) {
			return true
		}
	}

	return false
}
