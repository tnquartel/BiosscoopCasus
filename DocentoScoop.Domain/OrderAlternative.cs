//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Text.Json;
//using System.Threading.Tasks;

//namespace DocentoScoop.Domain
//{
//    public class OrderAlternative
//    {
//        public int orderNr { get; private set; }
//        public bool isStudentOrder { get; private set; }
//        public List<MovieTicket> movieTickets { get; set; } = new List<MovieTicket>();

//        public OrderAlternative(int orderNr, bool isStudentOrder)
//        {
//            this.isStudentOrder = isStudentOrder;
//            this.orderNr = orderNr;
//        }

//        public int getOrder()
//        {
//            return this.orderNr;
//        }

//        public void addSeatReservation(MovieTicket ticket)
//        {
//            this.movieTickets.Add(ticket);
//        }

//        public decimal calculatePrice()
//        {
//            decimal total = 0;
//            decimal toAdd = 0;
//            int count = 0;
//            List<MovieTicket> half = new List<MovieTiket>();
//            foreach (var MovieTicket in movieTickets)
//            {
//                DayOfWeek dayOfWeek = MovieTicket.GetScreeningDate().DayOfWeek;
//                bool isWeekend = dayOfWeek == DayOfWeek.Saturday || dayOfWeek == DayOfWeek.Sunday || dayOfWeek == DayOfWeek.Friday;
//                // studenten hebben altijd de tweede ticket gratis
//                // niet studenten hebben doordeweeks ook altijd de 2e gratis,
//                // worden toegevoegd aan een list om naar de SecondFree methode te sturen
//                if (!isWeekend || this.isStudentOrder)
//                {
//                    half.Add(MovieTicket);
//                }
//                else
//                {
//                    // prijs van het ticket word opgehaald uit MovieTicket en daarna toegevoegd aan total
//                    toAdd = MovieTicket.GetPrice();
//                    // als het een premium ticket is, kost het 3 dollar extra (geen student)
//                    if (MovieTicket.IsPremiumTicket())
//                    {
//                        toAdd += 3;
//                    }
//                    total += toAdd;
//                    count += 1;
//                }
//            }
//            // als er 6 of meer (niet 2e gratis) tickets besteld zijn krijg je hier 10% korting op
//            if (count >= 6)
//            {
//                total = total * 0.9M;
//            }
//            total = total + SecondFree(half);
//            return total;
//        }

//        public decimal SecondFree(List<MovieTicket> list)
//        {
//            decimal total = 0;
//            decimal toAdd = 0;
//            bool second = false;
//            foreach (var MovieTicket in list)
//            {
//                toAdd = MovieTicket.GetPrice();
//                // als het een premium ticket is, kost het 2 (student) of 3 (geen student) dollar extra 
//                if (MovieTicket.isPremiumTicket())
//                {
//                    if (isStudentOrder)
//                    {
//                        toAdd += 2;
//                    }
//                    else
//                    {
//                        toAdd += 3;
//                    }
//                }
//                if (second)
//                {
//                    toAdd = 0;
//                    second = false;
//                }
//                else
//                {
//                    second = true;
//                }
//                total += toAdd;
//            }
//            return total;
//        }

//        public void export(TicketExportFormat exportFormat)
//        {

//            string path = @"C:\Output\MyTest.txt";
//            if (!File.Exists(path))
//            {
//                // Create a file to write to.
//                using (StreamWriter sw = File.CreateText(path))
//                {
//                    switch (exportFormat)
//                    {
//                        case TicketExportFormat.PLAINTEXT:

//                            sw.WriteLine("OrderNr: " + this.orderNr);
//                            sw.WriteLine("IsStudentOrder: " + this.isStudentOrder);
//                            foreach (var item in movieTickets)
//                            {
//                                sw.WriteLine(item.ToString());
//                            }
//                            sw.WriteLine("TotalCost: $" + calculatePrice());
//                            break;

//                        case T:

//                            var aList = this.movieTickets.Select(item => new
//                            {
//                                rowNr = item.rowNr,
//                                seatNr = item.seatNr,
//                                isPremium = item.isPremium,
//                                dateAndTime = item.movieScreening.DateAndTime,
//                                pricePerSeat = item.movieScreening.GetPricePerSeat(),
//                                movieTitle = item.movieScreening.Movie.Title,
//                            }).ToList();

//                            var Result = new
//                            {
//                                orderNr = this.orderNr,
//                                isStudentOrder = this.isStudentOrder,
//                                tickets = new
//                                {
//                                    items = JsonSerializer.Serialize(aList),
//                                },
//                                totalPrice = calculatePrice()

//                            };
//                            sw.WriteLine(Result);
//                            break;

//                    }
//                }
//            }
//        }
//    }
//}
