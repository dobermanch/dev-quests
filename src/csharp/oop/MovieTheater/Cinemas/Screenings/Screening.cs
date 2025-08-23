using MovieTheater.Cinemas.Layouts;

namespace MovieTheater.Cinemas.Screenings;

public record Screening(Movie Movie, Theater Theater, DateTimeOffset StartTime, DateTimeOffset EndTime);