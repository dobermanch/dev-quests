from dataclasses import dataclass
from datetime import datetime, timedelta

from .movie import Movie
from .room import Room

@dataclass
class Screening:
    movie: Movie
    room: Room
    start_time: datetime

    @property
    def end_time(self):
        if "_end_time" not in self.__dict__:
            self._end_time = self.start_time + timedelta(minutes=self.movie.duration)

        return self._end_time
