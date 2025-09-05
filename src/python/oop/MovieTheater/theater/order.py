from dataclasses import dataclass
from datetime import datetime

from .person_age import PersonAge
from .seat import Seat
from .screening import Screening

@dataclass
class Order:
    id: str
    user_id: str
    screening: Screening
    date: datetime
    seats: list[(Seat, PersonAge)]
