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
            Assert.Equal(144.95M, actualResult.total);
        }

        [Fact]
        public void When_Calculate_Cart_With_One_Product_Price_0_Should_Be_Total_equal_50()
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
                price = 0.00M,
                quantity = 1
            });

            CartsService cartsService = new CartsService(_cartContext, _productContext);
            var actualResult = cartsService.calculate(cartModel, productsInCart);

            Assert.Equal(0.00M, actualResult.subtotal);
            Assert.Equal(25.00M, actualResult.total);
        }

        [Fact]
        public void When_Calculate_Cart_With_Zero_Product_Should_Be_Total_equal_0()
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
            CartsService cartsService = new CartsService(_cartContext, _productContext);
            var actualResult = cartsService.calculate(cartModel, productsInCart);

            Assert.Equal(0.00M, actualResult.subtotal);
            Assert.Equal(0.00M, actualResult.total);
        }

        [Fact]
        public void When_Calculate_Cart_With_Two_Products_Price_12_95_and_110_95_Should_Be_Total_equal_173_90()
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
                price = 12.95M,
                quantity = 1
            });
            productsInCart.Add(new ProductInCartModel{
                price = 110.95M,
                quantity = 1
            });

            CartsService cartsService = new CartsService(_cartContext, _productContext);
            var actualResult = cartsService.calculate(cartModel, productsInCart);
    
            Assert.Equal(123.90M, actualResult.subtotal);
            Assert.Equal(148.90M, actualResult.total);
        }

        [Fact]
        public void When_Calculate_Cart_With_One_Products_Price_12_95_With_2_Items_Should_Be_Total_equal_87_90()
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
                price = 12.95M,
                quantity = 2
            });

            CartsService cartsService = new CartsService(_cartContext, _productContext);
            var actualResult = cartsService.calculate(cartModel, productsInCart);
    
            Assert.Equal(25.90M, actualResult.subtotal);
            Assert.Equal(50.90M, actualResult.total);
        }

        [Fact]
        public void When_Calculate_Cart_With_Two_Products_Price_12_95_And_24_95_With_2_Items_Should_Be_Total_equal_125_80()
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
                price = 12.95M,
                quantity = 2
            });
            productsInCart.Add(new ProductInCartModel{
                price = 24.95M,
                quantity = 2
            });

            CartsService cartsService = new CartsService(_cartContext, _productContext);
            var actualResult = cartsService.calculate(cartModel, productsInCart);
    
            Assert.Equal(75.8M, actualResult.subtotal);
            Assert.Equal(100.80M, actualResult.total);
        }
    }
}

