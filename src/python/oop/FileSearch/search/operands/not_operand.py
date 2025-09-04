from .operand_base import *
from ..predicate_base import *
from ..file_info import *
from ..search_options import *

class NotOperand(OperandBase):
    def __init__(self, criteria: PredicateBase):
        self.__criteria = criteria

    def is_match(self, file: FileInfo, options: SearchOptions = None) -> bool:
        return not self.__criteria(file)
