
using DocentoScoop.Domain;

public class MovieTicket
    {
        private int rowNr;
        private int seatNr;
        private bool isPremium;
        private MovieScreening movieScreening;

        public MovieTicket(MovieScreening movieScreening, int rowNr, int seatNr, bool isPremium)
        {
            this.movieScreening = movieScreening;
            this.rowNr = rowNr;
            this.seatNr = seatNr;
            this.isPremium = isPremium;
        }

        public bool IsPremiumTicket()
        {
            return isPremium;
        }

        public decimal GetPrice()
        {
            return movieScreening.getPricePerSeat();
        }

        public DateTime GetScreeningDate()
        {
            return movieScreening.getDate();
        }

    }

