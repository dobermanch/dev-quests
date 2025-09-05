import uuid
from datetime import datetime

from .movie import Movie
from .order import Order
from .person_age import PersonAge
from .ticket import Ticket
from .seat import Seat
from .screening import Screening
from .screening_manager import ScreeningManager
from .pricing.price_calculator import PriceCalculator

from .room import Room


class Cinema:
    name: str
    location: str
    rooms: list[Room]

    def __init__(self, name: str, location: str, rooms: list[Room], screening_manager: ScreeningManager, calculator: PriceCalculator):
        self.name = name
        self.location = location
        self.rooms = rooms
        self._rooms_by_name = {room.number: room for room in rooms}
        self._screening_manager = screening_manager
        self._pricing_calculator = calculator
        self._orders = {}
        self._completed_orders = []

    def add_movie(self, movie: Movie) -> None:
        self._screening_manager.add_movie(movie)

    def get_movies(self) -> list[Movie]:
        return self._screening_manager.get_movies()

    def add_screening(self, screening: Screening) -> bool:
        if screening.room.number not in self._rooms_by_name:
            print(f"The '{screening.movie.title}' movie is not shown in this cinema")
            return False

        self._screening_manager.add_screening(screening)

    def get_screenings_by_movie(self, movie: Movie) -> list[Screening]:
        return self._screening_manager.get_screenings_by_movie(movie)

    def create_order(self, user_id: set, screening: Screening) -> Order:
        if not self._screening_manager.is_valid(screening):
            print(f"The '{screening}' screening is not valid")
            return None

        order = Order(uuid.uuid4(), user_id, screening, datetime.now(), [])

        self._orders[order.id] = order

        return order

    def get_available_seats(self, order: Order) -> list[Seat]:
        room = self._rooms_by_name[order.screening.room.number]
        return room.get_available_seats()

    def add_seat(self, order: Order, seat: Seat, age: PersonAge) -> Order:
        if order.id not in self._orders:
            print(f"The '{order.id}' order does not exists")
            return

        room = self._rooms_by_name[order.screening.room.number]

        if not room.lock_seat(order.user_id, seat):
            return order

        self._orders[order.id].seats.append((seat, age))

        return order

    def complete_order(self, order: Order) -> list[Ticket]:
        if order.id not in self._orders:
            print(f"The '{order.id}' order does not exists")
            return

        room = self._rooms_by_name[order.screening.room.number]
        order = self._orders[order.id]
        tickets = []
        for seat, age in order.seats:
            room.lock_seat(order.user_id, seat)

            price = self._pricing_calculator.calculate(Ticket(uuid.uuid4(), seat, age, order.screening, 0))
            ticket = Ticket(uuid.uuid4(), seat, age, order.screening, price)

            tickets.append(ticket)

        self._completed_orders.append((order, tickets))

        return tickets

    def cancel_order(self, order: Order):
        if order.id not in self._orders:
            print(f"The '{order.id}' order does not exists")
            return

        room = self._rooms_by_name[order.screening.room.number]
        order = self._orders[order.id]
        for seat, _ in order.seats:
            room.lock_seat(order.user_id, seat, order.screening.end_time)

        del self._orders[order.id]
