package criterias

import (
	"github.com/dobermanch/dev-quests/file-search/internal/models"
	"github.com/dobermanch/dev-quests/file-search/internal/predicates"
)

type BySizeMatchCriteria struct {
	size    int64
	compare CompareNumbers[int64]
}

func Size(size int64, comparer CompareNumbers[int64]) predicates.Predicate {
	return &BySizeMatchCriteria{
		size:    size,
		compare: comparer,
	}
}

func (c *BySizeMatchCriteria) Match(file *models.FileInfo) bool {
	return c.compare(file.Size(), c.size)
}
