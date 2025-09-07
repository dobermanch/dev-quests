from .elevator import Elevator
from .elevator_status import ElevatorStatus

class ElevatorButtonsPanel:
    def __init__(self, elevator: Elevator, system: ElevatorStatus):
        self._elevator = elevator
        self._system = system

    def get_buttons(self) -> set[int]:
        return self._elevator.floors

    def press_button(self, floor: int):
        if floor in self._elevator.floors:
            self._system.request_floor(self._elevator, floor)
