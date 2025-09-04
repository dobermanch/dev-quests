from abc import abstractmethod
from .file_info import FileInfo
from .search_options import SearchOptions

class PredicateBase:
    @abstractmethod
    def is_match(self, file: FileInfo, options: SearchOptions = None) -> bool:
        pass
