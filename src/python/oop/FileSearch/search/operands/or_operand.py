from typing import List
from .operand_base import *
from ..predicate_base import *
from ..file_info import *
from ..search_options import *

class OrOperand(OperandBase):
    def __init__(self, criterias: List[PredicateBase]):
        self.__criterias = criterias

    def is_match(self, file: FileInfo, options: SearchOptions = None) -> bool:
        for criteria in self.__criterias:
            if criteria.is_match(file, options):
                return True

        return False
