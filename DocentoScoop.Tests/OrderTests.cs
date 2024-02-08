using DocentoScoop.Domain.Exports;
using DocentoScoop.Domain.Models;
using DocentoScoop.Domain.Rules;
using DocentoScoop.Domain.Tools;

namespace DocentoScoop.Tests
{
    [TestClass]
    public class OrderTests
    {


        [TestMethod]
        public void Export_ShouldExecute_ForJson()
        {
            // Arrange
            Order order = CreateFakeOrder(6, 10M, false, false, true);

            // Act
            order.Export(OrderExportFormat.JSON);

            // Assert
            Assert.IsTrue(true);

        }

        [TestMethod]
        public void Export_ShouldExecute_ForPlainText()
        {
            // Arrange
            Order order = CreateFakeOrder(6, 10M, false, false, true);

            // Act
            order.Export(OrderExportFormat.PLAINTEXT);

            // Assert
            Assert.IsTrue(true);

        }



        [TestMethod]
        public void CalculatePrice_ShouldApplyDiscount_ForNonStudentOrderInTheWeekendOver6Tickets()
        {
            // Arrange
            Order order = CreateFakeOrder(6, 10M, false, false, true);

            // Act
            var price = order.CalculatePrice();

            // Assert
            Assert.IsTrue(price == 54M);

        }

        [TestMethod]
        public void CalculatePrice_ShouldReturnFree_ForEverySecondPremiumStudentTicketInTheWeekends()
        {
            // Arrange
            Order order = CreateFakeOrder(6, 10M, true, true, true);

            // Act
            var price = order.CalculatePrice();

            // Assert
            Assert.IsTrue(price == 36M);

        }

        [TestMethod]
        public void CalculatePrice_ShouldNotAddPremiumFee_ForNonPremiumTickets()
        {
            // Arrange
            Order order = CreateFakeOrder(2, 10M, false, false, true);

            // Act
            var price = order.CalculatePrice();

            // Assert
            Assert.IsTrue(price == 20M);

        }

        [TestMethod]
        public void CalculatePrice_ShouldAddPremiumFee_ForNonStudentOrders()
        {
            // Arrange
            Order order = CreateFakeOrder(2, 10M, true, false, false);

            // Act
            var price = order.CalculatePrice();

            // Assert
            Assert.IsTrue(price == 13M);

        }

        private static Order CreateFakeOrder(int numberOfTickets, decimal basePrice, bool isPremium, bool isStudentOrder, bool isWeekend)
        {
            // Move to factory later
            var ticketPriceRules = AssemblyScanner.GetInstancesOfType<ITicketPriceRule>();
            var orderExporters = AssemblyScanner.GetInstancesOfType<IOrderExporter>();

            Movie movie = new Movie("The Matrix");
            
            // Create a non-weekend movie screening
            DateTime date = isWeekend ? new DateTime(2024, 1, 27, 19, 0, 0, DateTimeKind.Local) : new DateTime(2024, 1, 31, 19, 0, 0, DateTimeKind.Local);
            MovieScreening movieScreening = new MovieScreening(movie, date, basePrice);
            Order order = new Order(1, isStudentOrder, ticketPriceRules, orderExporters);
            for (int i = 0; i < numberOfTickets; i++)
                order.AddSeatReservation(new MovieTicket(movieScreening, 1, 1, isPremium));
            return order;
        }
    }
}