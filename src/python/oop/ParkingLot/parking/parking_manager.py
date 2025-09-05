from .parking_spot import ParkingSpot
from .vehicle import Vehicle
from .vehicle_size import VehicleSize
from .spot_size import SpotSize

class ParkingManager:
    def __init__(self, spots: list[ParkingSpot]):
        self.__spots = spots

        self.__by_size_spots = {}
        self.__unavailable_spots = {}
        for spot in spots:
            if spot.size not in self.__by_size_spots:
                self.__by_size_spots[spot.size] = []

            self.__by_size_spots[spot.size].append(spot)

    def park_vehicle(self, vehicle: Vehicle) -> ParkingSpot:
        vehicleSize = self.__vehicle_to_spot_size(vehicle)

        suitedSize = [size for size in SpotSize if size >= vehicleSize]

        parkedSpot = None
        for size in suitedSize:
            if len(self.__by_size_spots[size]) <= 0:
                continue

            for spot in self.__by_size_spots[size]:
                if not spot.is_available:
                    continue

                parkedSpot = spot
                self.__unavailable_spots[parkedSpot.number] = parkedSpot
                self.__by_size_spots[size].remove(parkedSpot)
                break

            if parkedSpot:
                break

        return parkedSpot

    def vacate_spot(self, spot: ParkingSpot) -> None:
        spot.vacate()
        self.__unavailable_spots[spot.number].remove(spot)
        self.__by_size_spots[spot.size].append(spot)

    def __vehicle_to_spot_size(self, vehicle: Vehicle) -> SpotSize:
        match vehicle.size:
            case VehicleSize.SMALL:
                return SpotSize.COMPACT
            case VehicleSize.NORMAL:
                return SpotSize.NORMAL
            case VehicleSize.LARGE:
                return SpotSize.OVERSIZE

        raise ValueError(f"Provided unsupported '{vehicle.size}' vehicle sie")