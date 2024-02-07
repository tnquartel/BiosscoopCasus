using DocentoScoop.Domain.Models;

namespace DocentoScoop.Domain.Exports
{
    public interface IOrderExporter
    {
        void Export(Order order);

        OrderExportFormat Supports();
    }
}