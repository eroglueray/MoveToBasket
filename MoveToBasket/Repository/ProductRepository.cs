using MoveToBasket.API.Models;
using MoveToBasket.API.Interfaces;

namespace MoveToBasket.API.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(IMongoContext context) : base(context)
        {
        }
    }
}
