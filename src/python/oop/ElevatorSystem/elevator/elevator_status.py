from dataclasses import dataclass
from .direction import Direction

@dataclass
class ElevatorStatus:
    elevator_id: str
    current_floor: int
    direction: Direction
