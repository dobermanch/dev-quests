package main

import (
	"fmt"

	"github.com/dobermanch/dev-quests/file-search/internal"
	"github.com/dobermanch/dev-quests/file-search/internal/models"
	"github.com/dobermanch/dev-quests/file-search/internal/predicates"
	"github.com/dobermanch/dev-quests/file-search/internal/predicates/criterias"
	"github.com/dobermanch/dev-quests/file-search/internal/predicates/operands"
)

func main() {
	engine := internal.New("../..")
	options := models.SearchOptions{}

	var predicate predicates.Predicate = operands.Or([]predicates.Predicate{
		criterias.Size(63, criterias.Equals),
		operands.And([]predicates.Predicate{
			criterias.Name("predicate", criterias.CaseInsensitive),
			criterias.Extension("go", criterias.CaseSensitive),
		}),
	})
	files, err := engine.Search(predicate, options)

	if err != nil {
		fmt.Println(err)
		return
	}

	for _, file := range files {
		fmt.Printf("File %+v\n", file)
	}
}
