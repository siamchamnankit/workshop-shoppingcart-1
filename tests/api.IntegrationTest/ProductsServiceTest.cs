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

            var _productOptions = new DbContextOptionsBuilder<ProductsContext>().UseInMemoryDatabase("products_totalls").Options;
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

        [Fact]
        public void When_Get_Product_With_Id_2_Then_Show_Only_This_Product()
        {

            var _productOptions = new DbContextOptionsBuilder<ProductsContext>().UseInMemoryDatabase("products_detail").Options;
            var _productContext = new ProductsContext(_productOptions);

            ProductsModel productData = new ProductsModel{
                    id = 2,
                    name = "43 Piece dinner Set",
                    price = (Decimal)12.95,
                    availability = "InStock",
                    stockAvailability = 10,
                    age = "3_to_5",
                    gender = "FEMALE",
                    brand = "CoolKidz"
                };

            _productContext.Products.Add(productData);
            _productContext.SaveChanges();

            ProductsService productsService = new ProductsService(_productContext);
            var actualResult = productsService.getProductDetail(2);

            var expectedResult = _productContext.Products.First();

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void When_Filter_age_Is_3_to_5_And_gender_Is_female_Then_Show_Filtered_Products()
        {
            var _productOptions = new DbContextOptionsBuilder<ProductsContext>().UseInMemoryDatabase("products_list_filter").Options;
            var _productContext = new ProductsContext(_productOptions);
            ProductsService productsService = new ProductsService(_productContext);

            ProductsModel productDataId2 = new ProductsModel{
                id = 2,
                name = "43 Piece dinner Set",
                price = (Decimal)12.95,
                availability = "InStock",
                stockAvailability = 10,
                age = "3_to_5",
                gender = "FEMALE",
                brand = "CoolKidz"
            };

            ProductsModel productDataId1 = new ProductsModel{
                id = 1,
                name = "Balance Training Bicycle",
                price = (Decimal)119.95,
                availability = "InStock",
                stockAvailability = 10,
                age = "3_to_5",
                gender = "NEUTRAL",
                brand = "SportsFun"
            };

            ProductsModel productDataId7 = new ProductsModel{
                id = 7,
                name = "Best Friends Forever Magnetic Dress Up",
                price = (Decimal)24.95,
                availability = "InStock",
                stockAvailability = 10,
                age = "3_to_5",
                gender = "FEMALE",
                brand = "CoolKidz"
            };

            ProductsModel productDataId8 = new ProductsModel{
                id = 8,
                name = "City Garage Truck Lego",
                price = (Decimal)19.95,
                availability = "",
                stockAvailability = 10,
                age = "3_to_5",
                gender = "NEUTRAL",
                brand = "Lego"
            };

            ProductsModel productDataId20 = new ProductsModel{
                id = 20,
                name = "Creator Beach House Lego",
                price = (Decimal)39.95,
                availability = "",
                stockAvailability = 10,
                age = "6_to_8",
                gender = "NEUTRAL",
                brand = "Lego"
            };
            
            _productContext.Products.Add(productDataId2);
            _productContext.Products.Add(productDataId1);
            _productContext.Products.Add(productDataId7);
            _productContext.Products.Add(productDataId8);
            _productContext.Products.Add(productDataId20);
            _productContext.SaveChanges();

            List<ProductsModel> expectedResult = new List<ProductsModel>();
            expectedResult.Add(productDataId2);
            expectedResult.Add(productDataId7);

            var actualResult = productsService.list_products("3_to_5", "FEMALE");

            Assert.Equal(expectedResult, actualResult);
        }

        
        [Fact]
        public void When_Filter_age_Is_3_to_5_And_gender_Is_female_Then_Show_Filtered_Products_And_Total()
        {
            var _productOptions = new DbContextOptionsBuilder<ProductsContext>().UseInMemoryDatabase("products_list_filter_total").Options;
            var _productContext = new ProductsContext(_productOptions);
            ProductsService productsService = new ProductsService(_productContext);

            ProductsModel productDataId2 = new ProductsModel{
                id = 2,
                name = "43 Piece dinner Set",
                price = (Decimal)12.95,
                availability = "InStock",
                stockAvailability = 10,
                age = "3_to_5",
                gender = "FEMALE",
                brand = "CoolKidz"
            };

            ProductsModel productDataId1 = new ProductsModel{
                id = 1,
                name = "Balance Training Bicycle",
                price = (Decimal)119.95,
                availability = "InStock",
                stockAvailability = 10,
                age = "3_to_5",
                gender = "NEUTRAL",
                brand = "SportsFun"
            };

            ProductsModel productDataId7 = new ProductsModel{
                id = 7,
                name = "Best Friends Forever Magnetic Dress Up",
                price = (Decimal)24.95,
                availability = "InStock",
                stockAvailability = 10,
                age = "3_to_5",
                gender = "FEMALE",
                brand = "CoolKidz"
            };

            ProductsModel productDataId8 = new ProductsModel{
                id = 8,
                name = "City Garage Truck Lego",
                price = (Decimal)19.95,
                availability = "",
                stockAvailability = 10,
                age = "3_to_5",
                gender = "NEUTRAL",
                brand = "Lego"
            };

            ProductsModel productDataId20 = new ProductsModel{
                id = 20,
                name = "Creator Beach House Lego",
                price = (Decimal)39.95,
                availability = "",
                stockAvailability = 10,
                age = "6_to_8",
                gender = "NEUTRAL",
                brand = "Lego"
            };
            
            _productContext.Products.Add(productDataId2);
            _productContext.Products.Add(productDataId1);
            _productContext.Products.Add(productDataId7);
            _productContext.Products.Add(productDataId8);
            _productContext.Products.Add(productDataId20);
            _productContext.SaveChanges();

            List<ProductsModel> products = new List<ProductsModel>();
            products.Add(productDataId2);
            products.Add(productDataId7);

            var actualResult = productsService.list("3_to_5", "FEMALE");

            Assert.Equal(2, actualResult.total);
            Assert.Equal(products, actualResult.ProductsModel);
        }
    }
}

