namespace MovieTheater.Cinemas.Layouts;

public sealed record Seat(int Row, int Col)
{
    public string Id { get; } = Guid.NewGuid().ToString();
    public string Number { get; } = $"{Row}-{Col}";
};