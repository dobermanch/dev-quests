package internal

import (
	"io/fs"
	"path/filepath"

	"github.com/dobermanch/dev-quests/file-search/internal/models"
	"github.com/dobermanch/dev-quests/file-search/internal/predicates"
)

type Search interface {
	Search(predicate predicates.Predicate, options models.SearchOptions) ([]*models.FileInfo, error)
}

type FileSearch struct {
	path string
}

func New(path string) Search {
	return &FileSearch{
		path: path,
	}
}

func (s *FileSearch) Search(predicate predicates.Predicate, options models.SearchOptions) ([]*models.FileInfo, error) {
	files := []*models.FileInfo{}

	err := filepath.WalkDir(s.path, func(path string, d fs.DirEntry, err error) error {
		if err != nil {
			return err
		}

		if !d.IsDir() {
			file, err := models.File(path)
			if err == nil && predicate.Match(file) {
				files = append(files, file)
			}
		}

		return nil
	})

	if err != nil {
		return nil, err
	}

	return files, nil
}
