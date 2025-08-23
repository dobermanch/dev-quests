using MovieTheater.Cinemas.Booking;
using MovieTheater.Cinemas.Layouts;
using MovieTheater.Cinemas.Screenings;

namespace MovieTheater.Cinemas;

public record Cinema(string Name, string Location, ScreeningManager screeningManager, BookingService bookingService)
{
    private readonly List<Theater> _rooms = [];
    
    public event EventHandler<(Screening, bool)> ScreeningChanged; 

    public IReadOnlyCollection<Movie> Movies => screeningManager.Movies;

    public IReadOnlyCollection<Screening> GetScreenings(Movie movie) => screeningManager.GetScreenings(movie);

    public Order StartBooking(Screening screening, string userId) 
        => bookingService.StartOrder(screening, userId);

    public IReadOnlyCollection<Seat> GetAvailableSeats(Order order) 
        => screeningManager.GetAvailableSeats(order.Screening);

    public Order BookSeat(Order order, Seat seat, OrderSeatType seatType) 
        => bookingService.BookSeat(order, seat, seatType);

    public IReadOnlyCollection<Ticket> CompleteOrder(Order order)
    {
        var tickets = bookingService.CompleteOrder(order);
        
        // track sales
           
        return tickets;
    }

    public void AddTheater(Theater theater)
    {
        if (!_rooms.Contains(theater))
        {
            _rooms.Add(theater);
        }
    }

    public void AddScreening(Screening screening)
    {
        if (!_rooms.Contains(screening.Theater))
        {
            throw new InvalidOperationException("Screening room not found");
        }
        
        screeningManager.AddScreening(screening);
        ScreeningChanged?.Invoke(this, (screening, true));
    }

    public void RemoveScreening(Screening screening)
    {
        screeningManager.RemoveScreening(screening);
        ScreeningChanged?.Invoke(this, (screening, false));
    }
}