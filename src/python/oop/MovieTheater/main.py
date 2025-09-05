from theater.pricing.default_pricing_rate_strategy import *
from theater import *

def main() -> None:
    movie1 = Movie("Scary Movie 1", "A very interesting movie", 120)
    movie2 = Movie("Terminator", "SkyNet", 125)
    movie3 = Movie("Titanic", "There were enough space on that door", 183)

    rooms1 = [Room(f"Room {r}", SeatLayout([Seat(f"{s}", SeatType.COMFORT if s >= 90 else SeatType.STANDARD) for s in range(1, 100)])) for r in range(1, 10)]
    cinema1 = Cinema("Cinema 1", "location 1", rooms1, ScreeningManager(), PriceCalculator([DefaultPricingRateStrategy()]))
    cinema1.add_movie(movie1)
    cinema1.add_movie(movie2)
    cinema1.add_movie(movie3)
    cinema1.add_screening(Screening(movie1, rooms1[0], datetime.now() + timedelta(minutes=60)))
    cinema1.add_screening(Screening(movie2, rooms1[1], datetime.now() + timedelta(minutes=120)))
    cinema1.add_screening(Screening(movie3, rooms1[2], datetime.now() + timedelta(minutes=180)))

    rooms2 = [Room(f"Room {r}", SeatLayout([Seat(f"{s}", SeatType.COMFORT if s >= 90 else SeatType.STANDARD) for s in range(1, 100)])) for r in range(1, 10)]
    cinema2 = Cinema("Cinema 2", "location 2", rooms2, ScreeningManager(), PriceCalculator([DefaultPricingRateStrategy()]))
    cinema2.add_movie(movie1)
    cinema2.add_movie(movie3)
    cinema2.add_screening(Screening(movie1, rooms2[0], datetime.now() + timedelta(minutes=10)))
    cinema2.add_screening(Screening(movie3, rooms2[2], datetime.now() + timedelta(minutes=30)))

    booking = MovieSystem([
        cinema1,
        cinema2
    ])

    movies = booking.get_movies()
    my_movie = movies[0]
    cinemas = booking.get_cinemas_by_movie(my_movie)

    my_cinema = cinemas[0]
    screening = my_cinema.get_screenings_by_movie(my_movie)

    my_screening = screening[0]
    order = my_cinema.create_order("123", my_screening)
    seats = my_cinema.get_available_seats(order)

    my_cinema.add_seat(order, seats[0], PersonAge.CHILD)
    my_cinema.add_seat(order, seats[1], PersonAge.ADULT)
    my_cinema.add_seat(order, seats[2], PersonAge.SENIOR)

    tickets = my_cinema.complete_order(order)
    for ticket in tickets:
        print(ticket)


if __name__ == "__main__":
    main()
