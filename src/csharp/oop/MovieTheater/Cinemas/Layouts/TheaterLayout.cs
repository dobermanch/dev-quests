namespace MovieTheater.Cinemas.Layouts;

public class TheaterLayout
{
    private readonly List<Seat> _seats = new();
    private readonly Dictionary<string, Seat> _seatByNumber = new();

    public IReadOnlyCollection<Seat> Seats => _seats;

    public void AddSeat(Seat seat)
    {
        // validate seat
        _seats.Add(seat);
        _seatByNumber[seat.Number] = seat;
    }

    public Seat? GetSeat(string number) => _seatByNumber.GetValueOrDefault(number);
}