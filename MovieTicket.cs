using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocentoScoop
{


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

        public bool isPremiumTicket()
        {
            return isPremium;
        }

        public decimal getPrice()
        {
            return movieScreening.getPricePerSeat();
        }

        public DateTime getScreeningDate()
        {
            return movieScreening.getDate();
        }

    }
}
