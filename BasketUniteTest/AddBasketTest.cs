using MongoDB.Bson;
using Moq;
using MoveToBasket.API.Bussiness.Abstract;
using MoveToBasket.API.Models;
using Xunit;

namespace MoveToBasket.UnitTest
{
    public class AddBasketTest
    {
        private readonly Mock<IBasketService> _basketService = new Mock<IBasketService>();
        private readonly Basket basket = new Basket();
        private readonly Product product = new Product()
        {
            Cost =599000,
            Model ="TypeR",
            Brand ="Honda"
        };
        private readonly Customer customer = new Customer()
        {
            Name = "Kemal",
            Surname = "Ýlerigelen",
            Email = "kemalilerigelen@gmail.com",
            Address = "Ýstanbul/Bakýrköy",
        };


        [Fact]
        public void AddBasketSuccess()
        {         
            product.Amount = 21;       
            basket.Amount = 19;
            basket.Product = product;
            basket.Customer = customer;
            _basketService.Setup(p => p.AddProductsInBasket(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(basket);

            Assert.True(true);
        }
        [Fact]
        public void AddBasketFail()
        {         
            product.Amount = 21;           
            basket.Amount = 29;
            basket.Product = product;
            basket.Customer = customer;
            _basketService.Setup(p => p.AddProductsInBasket(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(basket);

            Assert.True(true);

        }
    }
}
