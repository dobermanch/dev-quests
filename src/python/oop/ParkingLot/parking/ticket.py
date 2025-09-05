from .parking_spot import ParkingSpot
from .vehicle import Vehicle

from dataclasses import dataclass
from datetime import datetime


@dataclass
class Ticket:
    id: str
    vehicle: Vehicle
    parking_spot: ParkingSpot
    park_time: datetime

    @property
    def leave_time(self) -> datetime:
        return self._leave_time if "_leave_time" in self.__dict__ else None

    @leave_time.setter
    def leave_time(self, value: datetime):
        self._leave_time = value

    @property
    def fee(self) -> float:
        return self._fee if "_fee" in self.__dict__ else 0

    @fee.setter
    def fee(self, value: float) -> float:
        self._fee = value