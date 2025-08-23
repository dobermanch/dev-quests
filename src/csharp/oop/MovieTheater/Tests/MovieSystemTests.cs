using MovieTheater.Cinemas;
using MovieTheater.Cinemas.Booking;
using MovieTheater.Cinemas.Booking.Pricing;
using MovieTheater.Cinemas.Layouts;
using MovieTheater.Cinemas.Screenings;

namespace MovieTheater.Tests;

public class MovieSystemTests
{
    [Fact]
    public void ShouldBookTickets()
    {
        // Build system
        var system = new MovieSystem();
        var movie1 = new Movie("Movie 1", "Comedy", TimeSpan.FromMinutes(120));
        var movie2 = new Movie("Movie 2", "Comedy", TimeSpan.FromMinutes(124));
        
        system.AddMovie(movie1);
        system.AddMovie(movie2);

        var screeningManager = new ScreeningManager();
        var cinema = new Cinema(
            "Theater 1",
            "In the middle of nowhere",
            screeningManager,
            new BookingService([
                new BaseRateStrategy(),
                new MorningRateStrategy()
            ], screeningManager));
        var room1Layout = new TheaterLayout();
        foreach (var row in Enumerable.Range(1, 10))
        {
            foreach (var col in Enumerable.Range(1, 12))
            {
                room1Layout.AddSeat(new Seat(row, col));
            }    
        }

        var theater = new Theater("1", room1Layout);
        cinema.AddTheater(theater);
        
        var startTime = DateTimeOffset.Now.AddHours(1);
        var screening1 = new Screening(movie1, theater, startTime, startTime.Add(movie1.Duration));
        cinema.AddScreening(screening1);
        
        startTime = startTime.Add(movie1.Duration).AddMinutes(20);
        var screening2 = new Screening(movie2, theater, startTime, startTime.Add(movie2.Duration));
        cinema.AddScreening(screening2);
        
        system.AddCinema(cinema);

        // Booking
        var myMovie = system.GetMovies().First();
        var myTheater = system.GeTheatersByMovie(myMovie).First();
        var myScreening = myTheater.GetScreenings(movie1).First();

        var myOrder = myTheater.StartBooking(myScreening, Guid.NewGuid().ToString());
        
        var seats = myTheater.GetAvailableSeats(myOrder).ToArray();
        myOrder = myTheater.BookSeat(myOrder, seats[0], OrderSeatType.Child);
        myOrder = myTheater.BookSeat(myOrder, seats[1], OrderSeatType.Adult);
        myOrder = myTheater.BookSeat(myOrder, seats[2], OrderSeatType.Senior);
        
        myOrder = myTheater.BookSeat(myOrder, seats[0], OrderSeatType.Senior);

        var tickets = myTheater.CompleteOrder(myOrder);
    }
}
