namespace DocentoScoop.Domain.Models;

public class MovieScreening
{
    private DateTime dateAndTime;
    private decimal pricePerSeat;

    public MovieScreening(Movie movie, DateTime dateAndTime, decimal pricePerSeat)
    {
        this.dateAndTime = dateAndTime;
        this.pricePerSeat = pricePerSeat;
    }

    public DateTime getDate()
    {
        return dateAndTime;
    }

    public decimal getPricePerSeat()
    {
        return pricePerSeat;
    }

    public string toString()
    {
        return dateAndTime.ToString() + " " + pricePerSeat;
    }
}


