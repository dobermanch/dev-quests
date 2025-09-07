from abc import ABC, abstractmethod
from .elevator import Elevator
from .direction import Direction

class DispatchStrategyBase(ABC):
    @abstractmethod
    def find_elevator(self, elevators: list[Elevator], current_floor: int, direction: Direction):
        pass
