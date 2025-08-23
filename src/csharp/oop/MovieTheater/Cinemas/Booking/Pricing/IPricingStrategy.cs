using MovieTheater.Cinemas.Layouts;
using MovieTheater.Cinemas.Screenings;

namespace MovieTheater.Cinemas.Booking.Pricing;

public interface IPricingStrategy
{
    decimal CalculatePrice(Screening screening, Seat seat, OrderSeatType seatType, decimal currentRate);
}