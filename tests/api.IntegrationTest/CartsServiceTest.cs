using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using api.IntegrationTest.Fixtures;
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
        public void When_Create_New_Cart_With_Product_ID2_And_Quantity2_And_Should_Be_Get_CartID1()
        {
            var _cartOptions = new DbContextOptionsBuilder<CartsContext>().UseInMemoryDatabase("carts").Options;
            var _cartContext = new CartsContext(_cartOptions);

            var _productOptions = new DbContextOptionsBuilder<ProductsContext>().UseInMemoryDatabase("products").Options;
            var _productContext = new ProductsContext(_productOptions);

            ProductsModel productsData = new ProductsModel{
                    id = 2,
                    name = "43 Piece dinner Set",
                    price = (Decimal)12.95,
                    availability = "InStock",
                    stockAvailability = 10,
                    age = "3_to_5",
                    gender = "FEMALE",
                    brand = "CoolKidz"
                };
            _productContext.Products.Add(productsData);
            _productContext.SaveChanges();

            CartsService cartsService = new CartsService(_cartContext, _productContext);
            var actualResult = cartsService.add(productsData, 1);

            Assert.Equal(1, actualResult.id);
        }

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
                price = (Decimal)119.95,
                quantity = 1
            });

            CartsService cartsService = new CartsService(_cartContext, _productContext);
            var actualResult = cartsService.calculate(cartModel, productsInCart);

            Assert.Equal((Decimal)119.95, actualResult.subtotal);
            Assert.Equal((Decimal)169.95, actualResult.total);
        }
    }
}

