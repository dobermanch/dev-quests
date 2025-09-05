from dataclasses import dataclass

from .screening import Screening
from .person_age import PersonAge
from .seat import Seat

@dataclass
class Ticket:
    id: str
    seat: Seat
    age: PersonAge
    screening: Screening
    Price: float
