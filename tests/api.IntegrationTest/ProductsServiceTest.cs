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

            ProductsContext _productContext = initialProductsContext("products_totalls");
                        
            _productContext.Products.Add(TestingProduct._1_Balance_Training_Bicycle);
            _productContext.Products.Add(TestingProduct._2_43_Piece_dinner_Set);
            _productContext.SaveChanges();

            ProductsService _productsService = new ProductsService(_productContext);
            var actualResult = _productsService.list();

            Assert.Equal(2, actualResult.total);
        }

        [Fact]
        public void When_Get_List_Products_Then_Show_All_Products()
        {

            ProductsContext _productContext = initialProductsContext("products_list");
            
            _productContext.Products.Add(TestingProduct._1_Balance_Training_Bicycle);
            _productContext.Products.Add(TestingProduct._2_43_Piece_dinner_Set);
            _productContext.SaveChanges();

            ProductsService productsService = new ProductsService(_productContext);
            var actualResult = productsService.list_products();

            var expectedResult = _productContext.Products.ToList();

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void When_Get_Product_With_Id_2_Then_Show_Only_This_Product()
        {

            ProductsContext _productContext = initialProductsContext("products_detail");

            _productContext.Products.Add(TestingProduct._2_43_Piece_dinner_Set);
            _productContext.SaveChanges();

            ProductsService productsService = new ProductsService(_productContext);
            var actualResult = productsService.getProductDetail(2);

            var expectedResult = _productContext.Products.First();

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void When_Filter_age_Is_3_to_5_And_gender_Is_female_Then_Show_Filtered_Products()
        {
            ProductsContext _productContext = initialProductsContext("products_list_filter");

            _productContext.Products.Add(TestingProduct._2_43_Piece_dinner_Set);
            _productContext.Products.Add(TestingProduct._1_Balance_Training_Bicycle);
            _productContext.Products.Add(TestingProduct._7_Best_Friends_Forever_Magnetic_Dress_Up);
            _productContext.Products.Add(TestingProduct._8_City_Garage_Truck_Lego);
            _productContext.Products.Add(TestingProduct._20_Creator_Beach_House_Lego);
            _productContext.SaveChanges();

            List<ProductsModel> expectedResult = new List<ProductsModel>();
            expectedResult.Add(TestingProduct._2_43_Piece_dinner_Set);
            expectedResult.Add(TestingProduct._7_Best_Friends_Forever_Magnetic_Dress_Up);

            ProductsService productsService = new ProductsService(_productContext);
            var actualResult = productsService.list_products("3_to_5", "FEMALE");

            Assert.Equal(expectedResult, actualResult);
        }

        
        [Fact]
        public void When_Filter_age_Is_3_to_5_And_gender_Is_female_Then_Show_Filtered_Products_And_Total()
        {
            ProductsContext _productContext = initialProductsContext("products_list_filter_totals");

            _productContext.Products.Add(TestingProduct._2_43_Piece_dinner_Set);
            _productContext.Products.Add(TestingProduct._1_Balance_Training_Bicycle);
            _productContext.Products.Add(TestingProduct._7_Best_Friends_Forever_Magnetic_Dress_Up);
            _productContext.Products.Add(TestingProduct._8_City_Garage_Truck_Lego);
            _productContext.Products.Add(TestingProduct._20_Creator_Beach_House_Lego);
            _productContext.SaveChanges();

            List<ProductsModel> products = new List<ProductsModel>();
            products.Add(TestingProduct._2_43_Piece_dinner_Set);
            products.Add(TestingProduct._7_Best_Friends_Forever_Magnetic_Dress_Up);

            ProductsService productsService = new ProductsService(_productContext);
            var actualResult = productsService.list("3_to_5", "FEMALE");

            Assert.Equal(2, actualResult.total);
            Assert.Equal(products, actualResult.ProductsModel);
        }
        
        private ProductsContext initialProductsContext(string databaseName) {
            var _productOptions = new DbContextOptionsBuilder<ProductsContext>().UseInMemoryDatabase(databaseName).Options;
            return new ProductsContext(_productOptions);
        }

    }

    public class TestingProduct {
            public static ProductsModel _1_Balance_Training_Bicycle = new ProductsModel{
                    id = 1,
                    name = "Balance Training Bicycle",
                    price = (Decimal)119.95,
                    availability = "InStock",
                    stockAvailability = 1,
                    age = "3_to_5",
                    gender = "NEUTRAL",
                    brand = "SportsFun"
                };

            public static ProductsModel _2_43_Piece_dinner_Set = new ProductsModel{
                    id = 2,
                    name = "43 Piece dinner Set",
                    price = (Decimal)12.95,
                    availability = "InStock",
                    stockAvailability = 10,
                    age = "3_to_5",
                    gender = "FEMALE",
                    brand = "CoolKidz"
                };

            
            public static ProductsModel _7_Best_Friends_Forever_Magnetic_Dress_Up = new ProductsModel{
                id = 7,
                name = "Best Friends Forever Magnetic Dress Up",
                price = (Decimal)24.95,
                availability = "InStock",
                stockAvailability = 10,
                age = "3_to_5",
                gender = "FEMALE",
                brand = "CoolKidz"
            };

            public static ProductsModel _8_City_Garage_Truck_Lego = new ProductsModel{
                id = 8,
                name = "City Garage Truck Lego",
                price = (Decimal)19.95,
                availability = "",
                stockAvailability = 10,
                age = "3_to_5",
                gender = "NEUTRAL",
                brand = "Lego"
            };

            public static ProductsModel _20_Creator_Beach_House_Lego = new ProductsModel{
                id = 20,
                name = "Creator Beach House Lego",
                price = (Decimal)39.95,
                availability = "",
                stockAvailability = 10,
                age = "6_to_8",
                gender = "NEUTRAL",
                brand = "Lego"
            };

    }
}

