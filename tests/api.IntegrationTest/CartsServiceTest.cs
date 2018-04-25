using System;
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
    }
}

