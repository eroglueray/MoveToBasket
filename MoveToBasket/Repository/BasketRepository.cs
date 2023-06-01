using MoveToBasket.API.Models;
using MoveToBasket.API.Interfaces;

namespace MoveToBasket.API.Repository
{
    public class BasketRepository : BaseRepository<Basket>, IBasketRepository
    {
        public BasketRepository(IMongoContext context) : base(context)
        {
        }
    }
}