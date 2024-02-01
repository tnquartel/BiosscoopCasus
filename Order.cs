using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace DocentoScoop
{
    public class Order
    {

        private int orderNr;
        private bool isStudentOrder;
        private List<MovieTicket> tickets = new List<MovieTicket>();
        private static int count = 0;

        public Order(int orderNr, bool isStudentOrder)
        {
            this.orderNr = orderNr;
            this.isStudentOrder = isStudentOrder;
        }

        public int getOrderNr()
        {
            return orderNr;
        }

        public void addSeatReservation(MovieTicket ticket)
        {
            tickets.Add(ticket);
        }

        public decimal calculatePrice()
        {
            decimal total = decimal.Zero;
            bool isWeekend = false;

            for (int i = 0; i < tickets.Count; i++)
            {
                MovieTicket ticket = tickets[i];
                int ticketNumber = i + 1;

                DateTime screeningDate = ticket.getScreeningDate();

                isWeekend = screeningDate.DayOfWeek == DayOfWeek.Saturday || screeningDate.DayOfWeek == DayOfWeek.Sunday;

                decimal ticketPrice = ticket.getPrice();

                // Premium fee for students is ... for non-students is ...
                if (ticket.isPremiumTicket())
                    ticketPrice += isStudentOrder ? 2 : 3;

                // Every second ticket is free for students or on weekdays
                if (isStudentOrder || !isWeekend)
                    if (i % 2 == 0)
                        ticketPrice = decimal.Zero;

                // On weekends, non-students pay full price unless the order consists of 6 or more tickets
                if (isWeekend && isStudentOrder && tickets.Count >= 6)
                    ticketPrice *= 0.9M;

                total += ticketPrice;
            }



            return total;
        }

        public void Export(TicketExportFormat exportFormat)
        {
            switch (exportFormat)
            {
                case TicketExportFormat.PLAINTEXT:
                    ExportToPlainText();
                    break;
                case TicketExportFormat.JSON:
                    ExportToJson();
                    break;
            }
        }

        private void ExportToPlainText()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Order: {this.orderNr} | Price: {this.calculatePrice():C2}");
            foreach (MovieTicket ticket in tickets)
                sb.AppendLine(ticket.ToString());

            string path = Path.Combine(Path.GetTempPath(), "", $"docentoscoop_order_{this.orderNr}.txt");
            File.WriteAllText(path, sb.ToString());

        }

        private void ExportToJson()
        {
            JsonObject jsonOrder = new JsonObject
            {
                { "orderNr", this.orderNr },
                { "isStudentOrder", this.isStudentOrder },
                { "totalPrice", this.calculatePrice() }
            };

            JsonArray jsonTickets = new JsonArray();
            foreach (MovieTicket ticket in tickets)
            {
                JsonObject jsonTicket = new JsonObject
                {
                    { "screeningDate", ticket.getScreeningDate() },
                    { "isPremiumTicket", ticket.isPremiumTicket() },
                    { "price", ticket.getPrice() },
                };
                jsonTickets.Add(jsonTicket);
            }
            jsonOrder.Add("tickets", jsonTickets);


            string path = Path.Combine(Path.GetTempPath(), "", $"docentoscoop_order_{this.orderNr}.json");
            File.WriteAllText(path, jsonOrder.ToString());


        }
    }
}
