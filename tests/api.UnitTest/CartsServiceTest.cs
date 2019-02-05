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

        private CartsModel _cartModel;
        private List<ProductInCartModel> _productsInCart;

        public CartsTest(){
            _cartModel = new CartsModel{
                userId = 1,
                createDatetime = DateTime.Now,
                updateDatetime = DateTime.Now
            };
            _productsInCart= new List<ProductInCartModel>();
        }

        [Fact]
        public void When_Calculate_Cart_With_One_Product_Price_119_95_Should_Be_Total_equal_169_95()
        {
            _productsInCart.Add(new ProductInCartModel{
                price = 119.95M,
                quantity = 1
            });

            CartsService cartsService = new CartsService(null, null);
            var actualResult = cartsService.calculate(_cartModel, _productsInCart);

            Assert.Equal(169.95M, actualResult.total);
        }

        [Fact]
        public void When_Calculate_Cart_With_One_Product_Price_0_Should_Be_Total_equal_50()
        {
            _productsInCart.Add(new ProductInCartModel{
                price = 0.00M,
                quantity = 1
            });

            CartsService cartsService = new CartsService(null, null);
            var actualResult = cartsService.calculate(_cartModel, _productsInCart);

            Assert.Equal(50.00M, actualResult.total);
        }

        [Fact]
        public void When_Calculate_Cart_With_Zero_Product_Should_Be_Total_equal_0()
        {
            CartsService cartsService = new CartsService(null, null);
            var actualResult = cartsService.calculate(_cartModel, _productsInCart);

            Assert.Equal(0.00M, actualResult.subtotal);
            Assert.Equal(0.00M, actualResult.total);
        }

        [Fact]
        public void When_Calculate_Cart_With_Two_Products_Price_12_95_and_110_95_Should_Be_Total_equal_173_90()
        {
            _productsInCart.Add(new ProductInCartModel{
                price = 12.95M,
                quantity = 1
            });

            _productsInCart.Add(new ProductInCartModel{
                price = 110.95M,
                quantity = 1
            });

            CartsService cartsService = new CartsService(null, null);
            var actualResult = cartsService.calculate(_cartModel, _productsInCart);
    
            Assert.Equal(123.90M, actualResult.subtotal);
            Assert.Equal(173.90M, actualResult.total);
        }

        [Fact]
        public void When_Calculate_Cart_With_One_Products_Price_12_95_With_2_Items_Should_Be_Total_equal_75_90()
        {
            _productsInCart.Add(new ProductInCartModel{
                price = 12.95M,
                quantity = 2
            });

            CartsService cartsService = new CartsService(null, null);
            var actualResult = cartsService.calculate(_cartModel, _productsInCart);
    
            Assert.Equal(25.90M, actualResult.subtotal);
            Assert.Equal(75.90M, actualResult.total);
        }

        [Fact]
        public void When_Calculate_Cart_With_Two_Products_Price_12_95_And_24_95_With_2_Items_Should_Be_Total_equal_125_80()
        {
            _productsInCart.Add(new ProductInCartModel{
                price = 12.95M,
                quantity = 2
            });
            _productsInCart.Add(new ProductInCartModel{
                price = 24.95M,
                quantity = 2
            });

            CartsService cartsService = new CartsService(null, null);
            var actualResult = cartsService.calculate(_cartModel, _productsInCart);
    
            Assert.Equal(75.8M, actualResult.subtotal);
            Assert.Equal(125.80M, actualResult.total);
        }
    }
}

