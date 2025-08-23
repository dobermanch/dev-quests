using MovieTheater.Cinemas.Booking.Pricing;
using MovieTheater.Cinemas.Layouts;
using MovieTheater.Cinemas.Screenings;

namespace MovieTheater.Cinemas.Booking;

public class BookingService(IReadOnlyCollection<IPricingStrategy> strategies, ScreeningManager screeningManager)
{
    public Order StartOrder(Screening screening, string userId) => new(Guid.NewGuid().ToString(), userId, screening);
    
    public Order BookSeat(Order order, Seat seat, OrderSeatType seatType)
    {
        if (screeningManager.LookSeat(order.Screening, seat, order.UserId))
        {
            if (order.Seats.All(it => it.Item1 != seat))
            {
                order.Seats.Add((seat, seatType));    
            }
            
            order.Status = OrderStatus.Proceed;
        }
        else
        {
            order.Status = OrderStatus.CannotBookSeat;
        }

        return order;
    }
    
    public IReadOnlyCollection<Ticket> CompleteOrder(Order order)
    {
        var tickets = new List<Ticket>();
        foreach ((Seat seat, OrderSeatType type) in order.Seats)
        {
            var price = decimal.Zero;
            foreach (var strategy in strategies)
            {
                price = strategy.CalculatePrice(order.Screening, seat, type, price);
            }
            
            if (screeningManager.BookSeat(order.Screening, seat, order.UserId))
            {
                tickets.Add(new Ticket(
                    Guid.NewGuid().ToString(), 
                    order.Screening.Theater, 
                    seat, 
                    order.Screening.StartTime,
                    price
                ));   
            }
            else
            {
                // do something
            }
        }
        
        return tickets;
    }
}