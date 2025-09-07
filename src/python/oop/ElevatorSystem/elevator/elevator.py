from .direction import Direction
from .elevator_status import ElevatorStatus

class Elevator:
    def __init__(self, id: str, floors: list[int]):
        self._id = id
        self._floors = set(floors)
        self._queue = []
        self._delayed_queue = []
        self._status = ElevatorStatus(self._id, 1, Direction.IDLE)

    @property
    def id(self):
        return self._id

    @property
    def floors(self) -> set[int]:
        return self._floors

    def get_status(self) -> ElevatorStatus:
        return self._status

    def add_floor_request(self, floor: int) -> None:
        if floor in self._queue or floor not in self.floors:
            return

        if (self._status.direction == Direction.UP and self._status.current_floor > floor) \
           or (self._status.direction == Direction.DOWN and self._status.current_floor < floor):
            return

        self._queue.append(floor)
        if self._status.current_floor > floor:
            self._queue.sort(reverse=True)
        else:
            self._queue.sort()

    def add_system_request(self, floor: int, direction: Direction) -> None:
        if floor in self._queue:
            return

        if self._status.direction != direction \
            or (self._status.direction == Direction.UP and self._status.current_floor > floor) \
            or (self._status.direction == Direction.DOWN and self._status.current_floor < floor):
            if floor not in self._delayed_queue:
                self._delayed_queue.append(floor)
            return

        self._queue.append(floor)

        if self._status.current_floor > floor:
            self._queue.sort(reverse=True)
        else:
            self._queue.sort()

    def _go_one_floor(self):
        if len(self._queue) <= 0:
            self._status = ElevatorStatus(self._id, self._status.current_floor, Direction.IDLE)
            return

        next_floor = self._queue[0]
        if self._status.current_floor > next_floor:
            self._status = ElevatorStatus(self._id, self._status.current_floor - 1, Direction.DOWN)
        elif self._status.current_floor < next_floor:
            self._status = ElevatorStatus(self._id, self._status.current_floor + 1, Direction.UP)
        else:
            self._queue = self._queue[1:]

            if len(self._queue) > 0:
                return

            self._status = ElevatorStatus(self._id, self._status.current_floor, Direction.IDLE)

            if len(self._delayed_queue) <= 0:
                return

            floor = self._delayed_queue[0]
            self._delayed_queue = self._delayed_queue[1:]

            self._queue.append(floor)
            self._status = ElevatorStatus(self._id, self._status.current_floor, Direction.DOWN if self._status.current_floor > floor else Direction.UP)
