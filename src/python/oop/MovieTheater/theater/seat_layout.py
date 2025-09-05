from datetime import datetime, timedelta

from .seat import *

class SeatLayout:
    LOCK_TIMEOUT = 5

    def __init__(self, seats: list[Seat]):
        self._available_seats = seats
        self._locks_by_seats = {}

    def get_available_seats(self):
        self._remove_expired_locks()

        return self._available_seats

    def lock_seat(self, user_id: str, seat: Seat, until: datetime = None) -> bool:
        if seat.number in self._locks_by_seats:
            lock = self._locks_by_seats[seat.number]

            if lock.id != user_id and not lock.is_expired():
                print(f"The '{seat.number}' is already locked by other user")
                return False

        if seat in self._available_seats:
            self._available_seats.remove(seat)

        self._locks_by_seats[seat.number] = SeatLock(
            user_id,
            seat,
            until if until else datetime.now() + timedelta(minutes=self.LOCK_TIMEOUT)
        )

        return True

    def unlock_seat(self, user_id: str, seat: Seat):
        if seat.number not in self._locks_by_seats:
            return

        lock = self._locks_by_seats[seat.number]
        if lock.id != user_id:
            print(f"The '{seat.number}' is locked by other user")
            return False

        del self._locks_by_seats[seat.number]
        self._available_seats.append(seat)

        print(f"The '{seat.number}' is unlocked")

    def _remove_expired_locks(self):
        for _, lock in self._locks_by_seats.items():
            if not lock.is_expired():
                continue

            self.unlock_seat(lock.user, lock.seat)
