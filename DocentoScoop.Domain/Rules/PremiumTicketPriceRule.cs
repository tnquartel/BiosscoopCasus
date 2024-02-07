using DocentoScoop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocentoScoop.Domain.Rules
{
    public class PremiumTicketPriceRule : ITicketPriceRule
    {
        private const decimal SURCHARGE_STUDENTS = 2M;
        private const decimal SURCHARGE_NON_STUDENTS = 3M;

        public decimal CalculateNewPrice(decimal currentPrice, int ticketOrder, MovieTicket ticket, Order order)
        {
            if (!ticket.IsPremiumTicket())
                return currentPrice;

            return currentPrice + (order.IsStudentOrder() ? SURCHARGE_STUDENTS : SURCHARGE_NON_STUDENTS);
        }

 
    }
}
