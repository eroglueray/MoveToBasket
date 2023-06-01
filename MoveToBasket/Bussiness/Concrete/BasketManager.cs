using MongoDB.Bson;
using MoveToBasket.API.Bussiness.Abstract;
using MoveToBasket.API.Interfaces;
using MoveToBasket.API.Models;
using System.Threading.Tasks;

namespace MoveToBasket.API.Bussiness.Concrete
{
    public class BasketManager : IBasketService
    {
        private IBasketRepository _basketRepository;
        private IProductRepository _productRepository;
        private ICustomerRepository _customerRepository;

        public BasketManager(IBasketRepository basketRepository, ICustomerRepository customerRepository, IProductRepository productRepository)
        {
            _basketRepository = basketRepository;
            _customerRepository = customerRepository;
            _productRepository = productRepository;
        }
        /// <summary>
        /// Add item into the basket.
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="customerId"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public async Task<Basket> AddProductsInBasket(string productId, string customerId, int amount)
        {

            Basket basket = new Basket();
            var product = await _productRepository.GetById(new ObjectId(productId));
            var customer = await _customerRepository.GetById(new ObjectId(customerId));
            basket.Product = product;
            basket.Customer = customer;
            basket.TotalPrice = basket.Product.Cost * amount;
            basket.Amount = amount;
            basket.Id = ObjectId.GenerateNewId();
            _basketRepository.Add(basket);

            return basket;
        }

    }
}
