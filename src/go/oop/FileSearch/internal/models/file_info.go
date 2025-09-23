package models

import (
	"os"
	"path/filepath"
	"strings"
)

type FileInfo struct {
	Path string
	info os.FileInfo
}

func File(path string) (*FileInfo, error) {
	file, err := os.Stat(path)
	if err != nil {
		return nil, err
	}
	return &FileInfo{
		Path: path,
		info: file,
	}, nil
}

func (f *FileInfo) Name() string {
	name := f.info.Name()
	if strings.Index(name, ".") <= 0 {
		return name
	}

	return strings.TrimSuffix(name, filepath.Ext(f.Path))
}

func (f *FileInfo) Extension() string {
	return filepath.Ext(f.Path)
}

func (f *FileInfo) Size() int64 {
	return f.info.Size()
}
