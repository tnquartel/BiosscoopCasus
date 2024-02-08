using DocentoScoop.Domain.Exports;
using DocentoScoop.Domain.Models.OrderState;
using DocentoScoop.Domain.Rules;
using DocentoScoop.Domain.Tools;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json.Nodes;

namespace DocentoScoop.Domain.Models;

public class Order : IOrderContext
{
    private readonly int orderNr;
    private readonly bool isStudentOrder;

    private readonly List<MovieTicket> tickets = new List<MovieTicket>();
    private readonly IEnumerable<ITicketPriceRule> ticketPriceRules = new List<ITicketPriceRule>();
    private readonly IEnumerable<IOrderExporter> orderExporters = new List<IOrderExporter>();

    private IOrderState? _currentState = null;


    public Order(int orderNr, bool isStudentOrder, IEnumerable<ITicketPriceRule> ticketPriceRules, IEnumerable<IOrderExporter> orderExporters)
    {
        this.orderNr = orderNr;
        this.isStudentOrder = isStudentOrder;
        this.ticketPriceRules = ticketPriceRules;
        this.orderExporters = orderExporters;

        this._currentState = new OrderCreatedState(this);
    }

    public void SetState(IOrderState state) => this._currentState = state;

    public int GetOrderNr()
    {
        return orderNr;
    }

    public bool IsStudentOrder()
    {
        return isStudentOrder;
    }

    public int GetTicketCount()
    {
        return tickets.Count;
    }

    public void AddSeatReservation(MovieTicket ticket)
    {
        tickets.Add(ticket);
    }

    public IEnumerable<MovieTicket> GetTickets() => this.tickets;


    public decimal CalculatePrice()
    {
        decimal total = decimal.Zero;

        for (int i = 0; i < tickets.Count; i++)
        {
            var ticket = tickets[i];
            var ticketPrice = ticket.GetPrice();

            foreach (var pricingRule in this.ticketPriceRules)
                if(ticketPrice > decimal.Zero)
                    ticketPrice = pricingRule.CalculateNewPrice(ticketPrice, i + 1, ticket, this);

            total += ticketPrice;
        }

        return total;
    }

    public void Export(OrderExportFormat exportFormat)
    {
        var exporter = this.orderExporters.SingleOrDefault(x => x.Supports() == exportFormat);
        if (exporter == null)
            throw new InvalidOperationException($"No OrderExporter found for {exportFormat}");

        exporter.Export(this);
    }

    public void Submit() => this._currentState!.Submit();

    public void Change(/* some params here */) => this._currentState!.Change(/* some params here */);
    
}