package predicates

import (
	"github.com/dobermanch/dev-quests/file-search/internal/models"
)

type Predicate interface {
	Match(file *models.FileInfo) bool
}

type PredicateBase struct {
	Options models.SearchOptions
}
