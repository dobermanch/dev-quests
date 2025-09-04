from .match_criteria_base import *
from ..file_info import *
from ..search_options import *

class BySizeMatchCriteria(MatchCriteriaBase[int]):
    def __init__(self, expectedSize: int):
        self.__expectedSize = expectedSize

    def is_match(self, file: FileInfo, options: SearchOptions = None) -> bool:
        return self.__expectedSize == self.__get_attribute(file)

    def __get_attribute(self, file: FileInfo) -> T:
        return file.size
