using DocentoScoop.Domain.Models;
using System.Text;

namespace DocentoScoop.Domain.Exports
{
    public class OrderPlainTextExporter : IOrderExporter
    {
        public void Export(Order order)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Order: {order.GetOrderNr()} | Price: {order.CalculatePrice():C2}");
            foreach (MovieTicket ticket in order.GetTickets())
                sb.AppendLine(ticket.ToString());

            string path = Path.Combine(Path.GetTempPath(), "", $"docentoscoop_order_{order.GetOrderNr()}.txt");
            File.WriteAllText(path, sb.ToString());
        }

        public OrderExportFormat Supports() => OrderExportFormat.PLAINTEXT;
    }
}