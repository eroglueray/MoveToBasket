
using MongoDB.Bson;
using MoveToBasket.API.Bussiness.Abstract;
using MoveToBasket.API.Interfaces;
using System.Threading.Tasks;

namespace MoveToBasket.API.Bussiness.Concrete
{
    public class StockControlManager : IStockControlService
    {
        private IProductRepository _productRepository;

        public StockControlManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        /// <summary>
        /// Stock control before the move to basket
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public async Task<bool> StockControl(string productId, int amount)
        {

            var product = await _productRepository.GetById(new ObjectId(productId));

            if (amount < product.Amount)
            {
                product.Amount = product.Amount - amount;
                _productRepository.Update(product);
                return true;
            }
            return false;
        }
    }
}
