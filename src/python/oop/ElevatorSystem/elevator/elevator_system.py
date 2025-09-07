from abc import *
from collections import deque

from .direction import Direction
from .dispatcher import Dispatcher
from .elevator import Elevator
from .elevator_status import ElevatorStatus

class ElevatorSystem:
    def __init__(self, elevators: list[Elevator], dispatcher: Dispatcher):
        self._elevators = elevators
        self._dispatcher = dispatcher

    def get_statuses(self) -> list[ElevatorStatus]:
        return [elevator.get_status() for elevator in self._elevators]

    def call_elevator(self, current_floor: int, direction: Direction) -> Elevator:
        return self._dispatcher.assign_elevator(current_floor, direction)

    def request_floor(self, elevator: Elevator, floor: int):
        elevator.add_floor_request(floor)

