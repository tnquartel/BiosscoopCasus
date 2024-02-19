using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocentoScoop.Domain.Models.OrderState
{
    public interface IOrderContext
    {
   
        void SetState(IOrderState state);

        DateTime GetScreeningDate();

    }
}
