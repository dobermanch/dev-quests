from abc import abstractmethod
from enum import IntEnum
from typing import Generic, TypeVar
from ..predicate_base import PredicateBase
from ..file_info import FileInfo

T = TypeVar('T')

class ComparisonType(IntEnum):
    Equal = 1,
    GreaterThan = 2,
    LessThan = 3,
    GreaterThanOrEqual = 4,
    LessThanOrEqual = 5

class MatchCriteriaBase(PredicateBase, Generic[T]):
    def __init__(self, comparison_type: ComparisonType):
        self._comparison_type = comparison_type

    @abstractmethod
    def __get_attribute(self, file: FileInfo) -> T:
        pass

    def _compare(self, expected_value: T, value: T) -> bool:
        match self._comparison_type:
            case ComparisonType.Equal:
                return value == expected_value
            case ComparisonType.GreaterThan:
                return value > expected_value
            case ComparisonType.LessThan:
                return value < expected_value
            case ComparisonType.GreaterThanOrEqual:
                return value >= expected_value
            case ComparisonType.LessThanOrEqual:
                return value <= expected_value

        return value == expected_value


