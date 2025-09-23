package criterias

import (
	"strings"

	"github.com/dobermanch/dev-quests/file-search/internal/models"
	"github.com/dobermanch/dev-quests/file-search/internal/predicates"
)

type ByExtensionMatchCriteria struct {
	extension string
	compare   CompareStrings
	predicates.PredicateBase
}

func Extension(extension string, comparer CompareStrings) predicates.Predicate {
	return &ByExtensionMatchCriteria{
		extension: extension,
		compare:   comparer,
	}
}

func (c *ByExtensionMatchCriteria) Match(file *models.FileInfo) bool {
	return c.compare(strings.ReplaceAll(file.Extension(), ".", ""), c.extension)
}
