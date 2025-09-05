from dataclasses import dataclass
from datetime import datetime
from enum import IntEnum

class SeatType(IntEnum):
    STANDARD = 1
    COMFORT = 2

@dataclass
class Seat:
    number: str
    type: SeatType

@dataclass
class SeatLock:
    id: str
    seat: Seat
    lock_until: datetime

    def is_expired(self):
        return datetime.now() > self.lock_until
