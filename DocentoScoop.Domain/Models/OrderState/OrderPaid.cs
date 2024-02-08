namespace DocentoScoop.Domain.Models.OrderState
{
    public class OrderPaid : IOrderState
    {
        private readonly IOrderContext _context;

        public OrderPaid(IOrderContext context)
        {
            _context = context;
        }

        public void Cancel() => throw new InvalidOperationException("Order paid, cannot cancel");


        public void Change() => throw new InvalidOperationException("Order paid, cannot change");


        public void Pay() => throw new InvalidOperationException("Order paid, cannot repay");


        public void CheckPayment(bool paid) => throw new InvalidOperationException("Order paid, cannot process payment");
  

        public void SendTickets()
        {
            // Send some tickets and then...
            _context.SetState(new OrderProcessed());
        }


        public void Submit() => throw new InvalidOperationException("Order paid, cannot submit");
    
    }
}
