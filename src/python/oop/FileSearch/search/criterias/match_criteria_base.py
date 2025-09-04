from abc import abstractmethod
from typing import Generic, TypeVar
from ..predicate_base import PredicateBase
from ..file_info import FileInfo

T = TypeVar('T')

class MatchCriteriaBase(PredicateBase, Generic[T]):
    @abstractmethod
    def __get_attribute(self, file: FileInfo) -> T:
        pass
