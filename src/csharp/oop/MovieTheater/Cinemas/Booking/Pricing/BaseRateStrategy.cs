using MovieTheater.Cinemas.Layouts;
using MovieTheater.Cinemas.Screenings;

namespace MovieTheater.Cinemas.Booking.Pricing;

public class BaseRateStrategy : IPricingStrategy
{
    public decimal CalculatePrice(Screening screening, Seat seat, OrderSeatType seatType, decimal currentRate)
    {
        // It can be based on room type, seat location, movie etc..
        return seatType switch
        {
            OrderSeatType.Child => 0.8m,
            OrderSeatType.Senior => 0.7m,
            _ => 1.0m
        };
    }
}