using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocentoScoop.Domain.Models.OrderState
{
    public class OrderProvisionedState : IOrderState
    {
        private readonly IOrderContext _context;

        public OrderProvisionedState(IOrderContext context)
        {
            _context = context;
        }

        public void Cancel() => _context.SetState(new OrderCancelledState());

        public void Change() => throw new InvalidOperationException("Order provisioned, cannot change");

        public void CheckPayment(bool paid)
        {
            this._context.SetState(paid ? new OrderPaidState(_context) : new OrderCancelledState());
        }

        public void Pay() => throw new InvalidOperationException("Order provisioned, checking payment later");

        public void SendTickets() => throw new InvalidOperationException("Order provisioned, not paid yet");
       

        public void Submit() => throw new InvalidOperationException("Order provisioned, already submitted");

    }
}
