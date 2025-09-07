from .elevator import *
from .elevator_status import *
from .direction import *

class HoleButtonsPanel:
    def __init__(self, floor: int, system: ElevatorStatus):
        self._floor = floor
        self._system = system

    def press_up(self) -> Elevator:
        return self._system.call_elevator(self._floor, Direction.UP)

    def press_down(self) -> Elevator:
        return self._system.call_elevator(self._floor, Direction.DOWN)
