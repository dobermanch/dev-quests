import os
from typing import List
from search import *

class SearchEngine:
    def __init__(self, basedir: str):
        if not basedir:
            raise ValueError("The basedir cannot be empty")

        self.__basedir = basedir

    def search(self, criteria: MatchCriteriaBase, options: SearchOptions) -> List[FileInfo]:
        if not criteria:
            return []

        foundFiles = []

        stack = []
        stack.append(self.__basedir)

        while stack:
            dir = stack.pop()
            with os.scandir(dir) as entries:
                for entry in entries:
                    if entry.is_file():
                        file = FileInfo(entry)
                        if criteria.is_match(file, options):
                            foundFiles.append(file)
                    elif entry.is_dir() and options.is_recursive:
                        stack.append(entry.path)

        return foundFiles
