using MoveToBasket.API.Models;
using System.Threading.Tasks;

namespace MoveToBasket.API.Bussiness.Abstract
{
    public interface IBasketService
    {
        Task<Basket> AddProductsInBasket(string customerId, string productId, int amount);
    }
}
