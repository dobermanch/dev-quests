using MovieTheater.Cinemas.Layouts;

namespace MovieTheater.Cinemas.Booking;

public sealed record Ticket(string Number, Theater Theater, Seat Seat, DateTimeOffset StartTime, decimal Price);