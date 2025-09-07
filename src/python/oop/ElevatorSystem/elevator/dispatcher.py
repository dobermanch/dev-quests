from .elevator import Elevator
from .direction import Direction
from .dispatch_strategy_base import DispatchStrategyBase

class Dispatcher:
    def __init__(self, elevators: list[Elevator], strategy: DispatchStrategyBase):
        self._elevators = elevators
        self._strategy = strategy

    def assign_elevator(self, current_floor: int, direction: Direction) -> Elevator:
        elevator = self._strategy.find_elevator(self._elevators, current_floor, direction)
        if elevator:
            elevator.add_system_request(current_floor, direction)

        return elevator
