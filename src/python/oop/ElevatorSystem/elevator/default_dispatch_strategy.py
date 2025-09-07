import random

from .dispatch_strategy_base import DispatchStrategyBase
from .elevator import Elevator
from .direction import Direction


class DefaultDispatchStrategy(DispatchStrategyBase):
    def find_elevator(self, elevators: list[Elevator], current_floor: int, direction: Direction):
        for elevator in elevators:
            if current_floor not in elevator.floors:
                continue

            status = elevator.get_status()
            if status.direction == Direction.IDLE:
                return elevator

            if status.direction == direction \
                and ((status.direction == Direction.DOWN and status.current_floor > current_floor) \
                or (status.direction == Direction.UP and status.current_floor < current_floor)):
                return elevator

        return elevators[random.randint(0, len(elevators) - 1)]
