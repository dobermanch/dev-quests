namespace ParkingLot.Parking.Fees;

public sealed class FeeCalculator(IReadOnlyCollection<IHourRateStrategy> strategies) : IFeeCalculator
{
    public decimal Calculate(Ticket ticket)
    {
        if (ticket.Invalid)
        {
            return 0;
        }
        
        decimal rate = 0;
        foreach (var strategy in strategies)
        {
            rate = strategy.Calculate(ticket, ticket.ParkTime, rate);
        }

        TimeSpan parkDuration = ticket.LeaveTime!.Value - ticket.ParkTime;
        var hours = parkDuration.Hours > 0 ? parkDuration.Hours : 1;
        
        return hours * rate;
    }
}