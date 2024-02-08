using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocentoScoop.Domain.Models.OrderState
{
    public class OrderReserved : IOrderState
    {
        private readonly IOrderContext _context;

        public OrderReserved(IOrderContext context)
        {
            _context = context;
        }

        public void Cancel() => _context.SetState(new OrderCancelled());


        public void Change()
        {
            // Change order, maybe calculate a new price
            // we could set a new state, but we're already in this state so 🤷‍
        }


        public void CheckPayment(bool paid)
        {
            this._context.SetState(paid ? new OrderPaid(_context) : new OrderProvisioned(_context));
        } 


        public void Pay() => _context.SetState(new OrderPaid(_context));


        public void Submit() => throw new InvalidOperationException("Order reserved, cannot submit");

        public void SendTickets() => throw new InvalidOperationException("Order reserved, cannot send tickets unless order is paid");

       
    }
}
