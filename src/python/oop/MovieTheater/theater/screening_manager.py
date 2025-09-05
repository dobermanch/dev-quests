from .movie import Movie
from .room import Room
from .screening import Screening

class ScreeningManager:
    def __init__(self):
        self._movies = {}
        self._screenings_by_room = {}
        self._screenings_by_movie = {}

    def add_movie(self, movie: Movie) -> None:
        if movie.title not in self._movies:
            self._movies[movie.title] = movie

    def get_movies(self) -> list[Movie]:
        return self._movies.values()

    def add_screening(self, screening: Screening) -> bool:
        if screening.movie.title not in self._movies:
            print(f"The '{screening.movie.title}' movie is not shown in this cinema")
            return False

        if screening.room.number not in self._screenings_by_room:
            self._screenings_by_room[screening.room.number] = []

        for existing in self._screenings_by_room[screening.room.number]:
            if (existing.start_time < screening.start_time and screening.start_time > existing.end_time) \
                or (existing.start_time < screening.end_time and screening.end_time > existing.end_time):
                print(f'Cannot add screening because it intersects with {existing} already existing screening')
                return False

        self._screenings_by_room[screening.room.number].append(screening)

        if screening.movie.title not in self._screenings_by_movie:
            self._screenings_by_movie[screening.movie.title] = []

        self._screenings_by_movie[screening.movie.title].append(screening)

    def get_screenings_by_movie(self, movie: Movie) -> list[Screening]:
        return self._screenings_by_movie[movie.title]

    def get_screenings_by_room(self, room: Room) -> list[Screening]:
        return self._screenings_by_room[room.number]

    def is_valid(self, screening: Screening) -> bool:
        if screening.room.number in self._screenings_by_room:
            for existing in self._screenings_by_room[screening.room.number]:
                if existing == screening:
                    # validate start time?
                    return True

        return False
