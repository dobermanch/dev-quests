from .vehicle import Vehicle
from .spot_size import SpotSize

from dataclasses import dataclass

@dataclass
class ParkingSpot:
    number: str
    size: SpotSize
    # here can be some attributes like disability, etc

    def __init__(self, number: str, size: SpotSize):
        self.number = number
        self.size = size
        self.__vehicle = None

    @property
    def is_available(self) -> bool:
        return False if self.__vehicle else True

    def park(self, vehicle: Vehicle) -> None:
        self.__vehicle = vehicle

    def vacate(self) -> Vehicle:
        vehicle = self.__vehicle
        self.__vehicle = None
        return vehicle