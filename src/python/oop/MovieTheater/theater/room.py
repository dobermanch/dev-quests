from datetime import datetime

from .seat import Seat
from .seat_layout import SeatLayout


class Room:
    number: str

    def __init__(self, number: str, layout: SeatLayout):
        self.number = number
        self._layout = layout

    def get_available_seats(self):
        return self._layout.get_available_seats()

    def lock_seat(self, user_id: str, seat: Seat, until: datetime = None) -> bool:
        return self._layout.lock_seat(user_id, seat, until)

    def unlock_seat(self, user_id: str, seat: Seat):
        return self._layout.unlock_seat(user_id, seat)
