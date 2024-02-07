// See https://aka.ms/new-console-template for more information
// Create a movie
using DocentoScoop.Domain.Exports;
using DocentoScoop.Domain.Models;
using DocentoScoop.Domain.Rules;
using DocentoScoop.Domain.Tools;

Console.WriteLine("Look at me, i am empty now");

//Movie movie = new Movie("The Matrix");
//Movie otherMovie = new Movie("John Wick");

//// Create a non-weekend movie screening
//DateTime wednesdayDateTime = new DateTime(2024, 1, 31, 19, 0, 0, DateTimeKind.Local); // January 31, 2024 is a Wednesday
//MovieScreening movieScreening = new MovieScreening(movie, wednesdayDateTime, 10.0M);

//// Create a weekend movie screening
//DateTime saturdayDateTime = new DateTime(2024, 2, 3, 19, 0, 0, DateTimeKind.Local); // February 3, 2024 is a Saturday
//MovieScreening weekendMovieScreening = new MovieScreening(movie, saturdayDateTime, 10.0M);

//// Add the screenings to the movie
//movie.AddScreening(movieScreening);
//otherMovie.AddScreening(weekendMovieScreening);

//// Create a non-premium movie ticket
//MovieTicket movieTicket = new MovieTicket(movieScreening, 1, 1, false);

//// Create a premium movie ticket
//MovieTicket premiumMovieTicket = new MovieTicket(movieScreening, 1, 1, true);

//// Move to factory later
//var ticketPriceRules = AssemblyScanner.GetInstancesOfType<ITicketPriceRule>();
//var orderExporters = AssemblyScanner.GetInstancesOfType<IOrderExporter>();

//// Create a non-student order
//Order order = new Order(1, false, ticketPriceRules, orderExporters);
//order.AddSeatReservation(premiumMovieTicket);
//order.AddSeatReservation(movieTicket); // This ticket should be free because it's the second ticket

//// Create a student order
//Order studentOrder = new Order(2, true, ticketPriceRules, orderExporters);
//studentOrder.AddSeatReservation(premiumMovieTicket);
//studentOrder.AddSeatReservation(movieTicket); // This ticket should be free because it's the second

//// Create a non-student order with 6 tickets for a weekend screening
//Order groupOrder = new Order(3, false, ticketPriceRules, orderExporters);
//for (int i = 0; i < 6; i++)
//    groupOrder.AddSeatReservation(new MovieTicket(weekendMovieScreening, 1, i + 1, true));

//// Export the orders
//order.Export(OrderExportFormat.PLAINTEXT);
//studentOrder.Export(OrderExportFormat.JSON);
//groupOrder.Export(OrderExportFormat.PLAINTEXT);