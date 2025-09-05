from .vehicle_size import VehicleSize

from dataclasses import dataclass


@dataclass
class Vehicle:
    size: VehicleSize
    licensePlate: str