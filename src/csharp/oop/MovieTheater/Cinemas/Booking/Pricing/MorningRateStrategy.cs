using MovieTheater.Cinemas.Layouts;
using MovieTheater.Cinemas.Screenings;

namespace MovieTheater.Cinemas.Booking.Pricing;

public class MorningRateStrategy : IPricingStrategy
{
    public decimal CalculatePrice(Screening screening, Seat seat, OrderSeatType seatType, decimal currentRate)
    {
        if (screening.StartTime.Hour <= 11)
        {
            return currentRate * 0.8m;
        }

        return currentRate;
    }
}