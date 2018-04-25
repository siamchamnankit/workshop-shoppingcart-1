using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using api.Models;
using api.Services;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Xunit;

namespace api.IntegrationTest
{
    public class CartsTest
    {
        [Fact]
        public void When_Calculate_Cart_With_One_Product_Price_119_95_Should_Be_Total_equal_169_95()
        {
            var _cartOptions = new DbContextOptionsBuilder<CartsContext>().UseInMemoryDatabase("carts").Options;
            var _cartContext = new CartsContext(_cartOptions);

            var _productOptions = new DbContextOptionsBuilder<ProductsContext>().UseInMemoryDatabase("products").Options;
            var _productContext = new ProductsContext(_productOptions);
            CartsModel cartModel = new CartsModel{
                userId = 1,
                createDatetime = DateTime.Now,
                updateDatetime = DateTime.Now
            };
            List<ProductInCartModel> productsInCart = new List<ProductInCartModel>();
            productsInCart.Add(new ProductInCartModel{
                price = 119.95M,
                quantity = 1
            });

            CartsService cartsService = new CartsService(_cartContext, _productContext);
            var actualResult = cartsService.calculate(cartModel, productsInCart);

            Assert.Equal(119.95M, actualResult.subtotal);
            Assert.Equal(169.95M, actualResult.total);
        }
    }
}

