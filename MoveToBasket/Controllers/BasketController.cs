using Microsoft.AspNetCore.Mvc;
using MoveToBasket.API.Models;
using System;
using MoveToBasket.API.Bussiness.Abstract;
using MoveToBasket.API.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MoveToBasket.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBasketService _basketService;
        private readonly IStockControlService _stockControlService;

        public BasketController( IUnitOfWork unitOfWork,IBasketRepository basketRepository, IProductRepository productRepository,IBasketService basketService,IStockControlService stockControlService)
        {
            _unitOfWork = unitOfWork;
            _basketRepository = basketRepository;
            _productRepository = productRepository;
            _stockControlService = stockControlService;
            _basketService = basketService;
        }


        [HttpGet("/GetBasket")]
        public async Task<ActionResult<IEnumerable<Basket>>> GetBasket()
        {
            var baskets = await _basketRepository.GetAll();

            return Ok(baskets);
        }
        [HttpGet("/GetProduct")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
            var products = await _productRepository.GetAll();

            return Ok(products);
        }
        // Sample Request:
        // ProductId: 61714b77f31a914870758c18
        // CustomerId: 61714b44e113baea33748424
        // Amount: 30

        [HttpPost("/addBasket")]
        public async Task<ActionResult<Basket>> AddBasket(string productId, string customerId, int amount)
        {          
            try
            {
                if (await _stockControlService.StockControl(productId, amount))
                {
                    var basket = await _basketService.AddProductsInBasket(productId, customerId, amount);
                    await _unitOfWork.Commit();
                    basket=await _basketRepository.GetById(basket.Id);
                    return Ok(basket);
                }
                else
                {
                    return NotFound("Out of stock.");
                }
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }
    }
}
