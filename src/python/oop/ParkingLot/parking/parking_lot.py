from .fee.fee_calculator import FeeCalculator
from .parking_manager import ParkingManager
from .ticket import Ticket
from .vehicle import Vehicle

from datetime import datetime
import uuid

class ParkingLot:
    def __init__(self, parking_manager: ParkingManager, fee_calculator: FeeCalculator):
        self.__parking_manager = parking_manager
        self.__fee_calculator = fee_calculator
        self.__issued_tickets = {}

    def park(self, vehicle: Vehicle) -> Ticket:
        spot = self.__parking_manager.park_vehicle(vehicle)
        if not spot:
            print("Parking spot not found")
            return

        print(f"The parking spot '{spot.number}' assigned")

        ticket = Ticket(uuid.uuid4(), vehicle, spot, datetime.now())
        self.__issued_tickets[ticket.id] = ticket

        print(f"The ticket issued {str(ticket)}")

        # in case of in-memory return ticket copy
        return ticket

    def leave(self, ticket: Ticket):
        if ticket.id not in self.__issued_tickets:
            print(f"Provided ticket not valid")
            return

        original = self.__issued_tickets[ticket.id]
        if original.leave_time:
            print(f"Ticket already processed")
            return

        # ticket validation here
        original.leave_time = datetime.now()
        original.fee = self.__fee_calculator.calculate(ticket)

        print(f"Total fee: {original.fee}")

        return ticket
