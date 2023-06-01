using System.Threading.Tasks;

namespace MoveToBasket.API.Bussiness.Abstract
{
    public interface IStockControlService
    {
        Task<bool> StockControl(string productId, int amount);
    }
}
