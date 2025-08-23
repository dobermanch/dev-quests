using MovieTheater.Cinemas.Layouts;
using MovieTheater.Cinemas.Screenings;

namespace MovieTheater.Cinemas.Booking;

public record Order(string Number, string UserId, Screening Screening)
{
    public List<(Seat, OrderSeatType)> Seats { get; } = [];
    public OrderStatus Status { get; set; } 
}