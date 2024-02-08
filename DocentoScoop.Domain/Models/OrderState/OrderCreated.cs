using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocentoScoop.Domain.Models.OrderState
{
    public class OrderCreated : IOrderState
    {
        private readonly IOrderContext _context;

        public OrderCreated(IOrderContext context)
        {
            this._context = context;
        }

        public void Cancel() => throw new InvalidOperationException("Cannot cancel, order not reserved yet");

        public void Change() => throw new InvalidOperationException("Cannot change, not submitted");


        public void CheckPayment(bool paid) => throw new InvalidOperationException("Cannot check payment, not submitted");


        public void Pay() => throw new InvalidOperationException("Cannot pay, not submitted");
        

        public void Submit() => _context.SetState(new OrderReserved(_context));
        

        public void SendTickets() => throw new InvalidOperationException("Order cancelled, cannot submit");
        
    }
}
