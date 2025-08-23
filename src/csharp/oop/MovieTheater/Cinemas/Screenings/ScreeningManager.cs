using MovieTheater.Cinemas.Layouts;

namespace MovieTheater.Cinemas.Screenings;

public class ScreeningManager
{
    private readonly List<Screening> _screenings = new();
    private readonly Dictionary<Movie, List<Screening>> _screeningsByMovie = new();
    private readonly Dictionary<Screening, IReadOnlyCollection<Seat>> _seatsByScreening = new();
    private readonly Dictionary<Seat, SeatLock> _locksBySeat = new();
    
    public IReadOnlyCollection<Movie> Movies => _screeningsByMovie.Keys;
    
    public void AddScreening(Screening screening)
    {
        if (_screenings.Contains(screening))
        {
            return;
        }
        
        // Validate screening, e.g. intersection 
        _screenings.Add(screening);
        if (!_screeningsByMovie.TryGetValue(screening.Movie, out var movieScreenings))
        {
            _screeningsByMovie[screening.Movie] = movieScreenings = new();
        }

        _seatsByScreening[screening] = screening.Theater.Layout.Seats;
        
        movieScreenings.Add(screening);
    }
    
    public void RemoveScreening(Screening screening)
    {
        if (_screeningsByMovie.TryGetValue(screening.Movie, out var movieScreenings))
        {
            movieScreenings.Remove(screening);
        }
        
        _seatsByScreening.Remove(screening);
        _screenings.Remove(screening);
    }

    public IReadOnlyCollection<Seat> GetAvailableSeats(Screening screening)
    {
        lock (screening)
        {
            return _seatsByScreening[screening]
                .Where(it => !_locksBySeat.TryGetValue(it, out var seatLock) || (!seatLock.IsLocked && !seatLock.IsBooked))
                .Select(it => it)
                .ToArray();
        }
    }

    public bool LookSeat(Screening screening, Seat seat, string userId)
    {
        lock (screening)
        {
            _locksBySeat.TryGetValue(seat, out var seatLock);

            if (seatLock != null)
            {
                if (seatLock.IsBooked)
                {
                    return false;
                }

                if (seatLock.IsLocked && seatLock.UserId != userId)
                {
                    return false;
                }
            }

            _locksBySeat[seat] = new SeatLock(seat, userId, DateTimeOffset.UtcNow.AddMinutes(5));
            
            return true;
        }
    }
    
    public bool BookSeat(Screening screening, Seat seat, string userId)
    {
        lock (screening)
        {
            _locksBySeat.TryGetValue(seat, out var seatLock);

            if (seatLock != null && seatLock.UserId != userId)
            {
                return false;
            }
            
            _locksBySeat[seat] = new SeatLock(seat, userId, DateTimeOffset.UtcNow.Add(screening.Movie.Duration))
            {
                IsBooked = true
            };
            
            return true;
        }
    }

    public IReadOnlyCollection<Screening> GetScreenings(Movie movie)
    {
        // can be filtered, returns only actual ones
        return _screeningsByMovie.TryGetValue(movie, out var screenings) ? screenings : [];
    }

    private record SeatLock(Seat Seat, string UserId, DateTimeOffset LockUntil)
    {
        public bool IsLocked => DateTimeOffset.UtcNow < LockUntil;
        public bool IsBooked { get; set; }
    }
}