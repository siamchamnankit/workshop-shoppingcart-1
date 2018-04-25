using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.IntegrationTest.Fixtures;
using api.Models;
using api.Services;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Xunit;

namespace api.IntegrationTest
{
    public class ProductsTest
    {
        [Fact]
        public void When_Get_List_Then_Total_Products_Should_Be_2()
        {

            var _productOptions = new DbContextOptionsBuilder<ProductsContext>().UseInMemoryDatabase("products_total").Options;
            var _productContext = new ProductsContext(_productOptions);

            ProductsModel productData1 = new ProductsModel{
                    id = 1,
                    name = "Balance Training Bicycle",
                    price = (Decimal)119.95,
                    availability = "InStock",
                    stockAvailability = 1,
                    age = "3_to_5",
                    gender = "NEUTRAL",
                    brand = "SportsFun"
                };

            ProductsModel productData2 = new ProductsModel{
                    id = 2,
                    name = "43 Piece dinner Set",
                    price = (Decimal)12.95,
                    availability = "InStock",
                    stockAvailability = 10,
                    age = "3_to_5",
                    gender = "FEMALE",
                    brand = "CoolKidz"
                };
            
            _productContext.Products.Add(productData1);
            _productContext.Products.Add(productData2);
            _productContext.SaveChanges();

            ProductsService productsService = new ProductsService(_productContext);
            var actualResult = productsService.list();

            Assert.Equal(2, actualResult.total);
        }

        [Fact]
        public void When_Get_List_Products_Then_Show_All_Products()
        {

            var _productOptions = new DbContextOptionsBuilder<ProductsContext>().UseInMemoryDatabase("products_list").Options;
            var _productContext = new ProductsContext(_productOptions);

            ProductsModel productData1 = new ProductsModel{
                    id = 1,
                    name = "Balance Training Bicycle",
                    price = (Decimal)119.95,
                    availability = "InStock",
                    stockAvailability = 1,
                    age = "3_to_5",
                    gender = "NEUTRAL",
                    brand = "SportsFun"
                };

            ProductsModel productData2 = new ProductsModel{
                    id = 2,
                    name = "43 Piece dinner Set",
                    price = (Decimal)12.95,
                    availability = "InStock",
                    stockAvailability = 10,
                    age = "3_to_5",
                    gender = "FEMALE",
                    brand = "CoolKidz"
                };
            
            _productContext.Products.Add(productData1);
            _productContext.Products.Add(productData2);
            _productContext.SaveChanges();

            ProductsService productsService = new ProductsService(_productContext);
            var actualResult = productsService.list_products();

            var expectedResult = _productContext.Products.ToList();

            Assert.Equal(expectedResult, actualResult);
        }
    }
}

