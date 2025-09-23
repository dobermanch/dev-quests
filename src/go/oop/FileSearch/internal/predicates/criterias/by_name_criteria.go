package criterias

import (
	"github.com/dobermanch/dev-quests/file-search/internal/models"
	"github.com/dobermanch/dev-quests/file-search/internal/predicates"
)

type ByNameMatchCriteria struct {
	name    string
	compare CompareStrings
}

func Name(targetName string, comparer CompareStrings) predicates.Predicate {
	return &ByNameMatchCriteria{
		name:    targetName,
		compare: comparer,
	}
}

func (c *ByNameMatchCriteria) Match(file *models.FileInfo) bool {
	return c.compare(file.Name(), c.name)
}
