from .match_criteria_base import *
from ..file_info import *
from ..search_options import *

class ByNameMatchCriteria(MatchCriteriaBase[str]):
    def __init__(self, expectedName: str):
        self.__expectedName = expectedName

    def is_match(self, file: FileInfo, options: SearchOptions = None) -> bool:
        if options and options.is_caseSensitive:
            return self.__expectedName.lower() == self.__get_attribute(file).lower()

        return self.__expectedName == self.__get_attribute(file)

    def __get_attribute(self, file: FileInfo) -> T:
        return file.name
