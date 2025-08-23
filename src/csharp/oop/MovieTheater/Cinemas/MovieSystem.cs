using MovieTheater.Cinemas.Screenings;

namespace MovieTheater.Cinemas;

public class MovieSystem
{
    private readonly List<Cinema> _cinemas = new();
    private readonly List<Movie> _movies = new();
    private readonly Dictionary<Movie, HashSet<Cinema>> _theatersByMovie = new();
    
    public IReadOnlyCollection<Cinema> GetTheaters() => _cinemas;
    
    public IReadOnlyCollection<Movie> GetMovies() => _movies;
    
    public IReadOnlyCollection<Cinema> GeTheatersByMovie(Movie movie)
        => _theatersByMovie.TryGetValue(movie, out var theaters) ? theaters : [];
    
    public void AddCinema(Cinema cinema)
    {
        if (_cinemas.Contains(cinema))
        {
            return;
        }
        
        _cinemas.Add(cinema);
        
        cinema.ScreeningChanged += TheaterOnScreeningChanged;
        
        foreach (var movie in cinema.Movies)
        {
            if (!_theatersByMovie.TryGetValue(movie, out var theaters))
            {
                _theatersByMovie[movie] = theaters = [];    
            }

            theaters.Add(cinema);
        }
    }

    public void RemoveCinema(Cinema cinema)
    {
        cinema.ScreeningChanged -= TheaterOnScreeningChanged;

        foreach (var movie in cinema.Movies)
        {
            if (_theatersByMovie.TryGetValue(movie, out var theaters))
            {
                theaters.Remove(cinema);    
            }
        }
        
        _cinemas.Remove(cinema);
    }

    public void AddMovie(Movie movie)
    {
        if (!_movies.Contains(movie))
        {
            _movies.Add(movie);
        }
    }

    public void RemoveMovie(Movie movie) => _movies.Remove(movie);
    
    private void TheaterOnScreeningChanged(object? sender, (Screening screening, bool added) args)
    {
        if (!_theatersByMovie.TryGetValue(args.screening.Movie, out var theaters) || sender is not Cinema theater)
        {
            return;
        }

        if (args.added)
        {
            theaters.Add(theater);
        }
        else
        {
            theaters.Remove(theater);
        }
    }
}