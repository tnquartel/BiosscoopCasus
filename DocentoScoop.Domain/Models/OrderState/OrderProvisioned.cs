using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocentoScoop.Domain.Models.OrderState
{
    public class OrderProvisioned : IOrderState
    {
        private readonly IOrderContext _context;

        public OrderProvisioned(IOrderContext context)
        {
            _context = context;
        }

        public void Cancel() => _context.SetState(new OrderCancelled());

        public void Change() => throw new InvalidOperationException("Order provisioned, cannot change");

        public void CheckPayment(bool paid)
        {
            this._context.SetState(paid ? new OrderPaid(_context) : new OrderCancelled());
        }

        public void Pay() => throw new InvalidOperationException("Order provisioned, checking payment later");

        public void SendTickets() => throw new InvalidOperationException("Order provisioned, not paid yet");
       

        public void Submit() => throw new InvalidOperationException("Order provisioned, already submitted");

    }
}
