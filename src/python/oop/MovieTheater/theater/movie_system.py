
from .cinema import Cinema
from .movie import Movie


class MovieSystem:
    def __init__(self, cinemas: list[Cinema]):
        self._cinema = cinemas

        self._cinema_by_name = {}
        self._cinema_by_movie = {}
        self._movies = {}
        for cinema in cinemas:
            self._cinema_by_name[cinema.name] = cinema
            for movie in cinema.get_movies():
                if movie.title not in self._movies:
                    self._movies[movie.title] = movie

                if movie.title not in self._cinema_by_movie:
                    self._cinema_by_movie[movie.title] = []

                self._cinema_by_movie[movie.title].append(cinema)

    def get_cinema(self, name: str) -> Cinema:
        return self._cinema_by_name[name]

    def get_movies(self) -> list[Movie]:
        return list(self._movies.values())

    def get_cinemas_by_movie(self, movie: Movie) -> list[Cinema]:
        return list(self._cinema_by_movie[movie.title])
