from turtle import delay
from parking.fee.base_rate_strategy import BaseRatesStrategy
from parking.fee.hourly_rate_strategy import HourlyRateStrategy
from parking import *

def main():
    calculator = FeeCalculator([
        BaseRatesStrategy(),
        HourlyRateStrategy()
    ])

    sizes = [size for size in SpotSize]
    parking_manager = ParkingManager([
        ParkingSpot(str(p), sizes[p % len(sizes)]) for p in range(1, 100)
    ])

    parking_lot = ParkingLot(parking_manager, calculator)

    car = Vehicle(VehicleSize.NORMAL, "abs")
    ticket = parking_lot.park(car)
    if ticket:
        delay(1000)
        
        ticket = parking_lot.leave(ticket)


if __name__ == "__main__":
    main()
