from .match_criteria_base import *
from ..file_info import *
from ..search_options import *

class ByExtensionMatchCriteria(MatchCriteriaBase[str]):
    def __init__(self, expectedExtension: str):
        self.__expectedExtension = expectedExtension

    def is_match(self, file: FileInfo, options: SearchOptions = None) -> bool:
        if options and options.is_caseSensitive:
            return self.__expectedExtension.lower() == self.__get_attribute(file).lower()

        return self.__expectedExtension == self.__get_attribute(file)

    def __get_attribute(self, file: FileInfo) -> T:
        return file.extension

