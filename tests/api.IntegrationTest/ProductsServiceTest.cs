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
    public class ProductsTest : IClassFixture<DatabaseFixture>
    {
        private DatabaseFixture _fixture;
        private ProductsService _productsService;

        public ProductsTest(DatabaseFixture fixture)
        {
            this._fixture = fixture;

            _productsService = new ProductsService(fixture.productContext);
        }


        [Fact]
        public void When_Get_List_Then_Total_Products_Should_Be_5()
        {
            var expectedResult = new List<ProductsModel>();
            expectedResult.Add(_fixture._1_Balance_Training_Bicycle);
            expectedResult.Add(_fixture._2_43_Piece_dinner_Set);
            expectedResult.Add(_fixture._7_Best_Friends_Forever_Magnetic_Dress_Up);
            expectedResult.Add(_fixture._8_City_Garage_Truck_Lego);
            expectedResult.Add(_fixture._20_Creator_Beach_House_Lego);

            var actualResult = _productsService.list();

            Assert.Equal(5, actualResult.total);
            Assert.Equal(expectedResult, actualResult.ProductsModel);
            
        }

        [Fact]
        public void When_Get_Product_With_Id_2_Then_Show_Only_This_Product()
        {
            var actualResult = _productsService.getProductDetail(2);
            Assert.Equal(_fixture._2_43_Piece_dinner_Set, actualResult);
        }


        [Fact]
        public void When_Filter_age_Is_3_to_5_And_gender_Is_female_Then_Show_Filtered_Products_And_Total()
        {
            var expectedResult = new List<ProductsModel>();
            expectedResult.Add(_fixture._2_43_Piece_dinner_Set);
            expectedResult.Add(_fixture._7_Best_Friends_Forever_Magnetic_Dress_Up);

            var actualResult = _productsService.list("3_to_5", "FEMALE");

            Assert.Equal(2, actualResult.total);
            Assert.Equal(expectedResult, actualResult.ProductsModel);
        }

    }

    public class DatabaseFixture : IDisposable
    {
        public ProductsContext productContext;

        public ProductsModel _1_Balance_Training_Bicycle = new ProductsModel
        {
            id = 1,
            name = "Balance Training Bicycle",
            price = (Decimal)119.95,
            availability = "InStock",
            stockAvailability = 1,
            age = "3_to_5",
            gender = "NEUTRAL",
            brand = "SportsFun"
        };

        public ProductsModel _2_43_Piece_dinner_Set = new ProductsModel
        {
            id = 2,
            name = "43 Piece dinner Set",
            price = (Decimal)12.95,
            availability = "InStock",
            stockAvailability = 10,
            age = "3_to_5",
            gender = "FEMALE",
            brand = "CoolKidz"
        };


        public ProductsModel _7_Best_Friends_Forever_Magnetic_Dress_Up = new ProductsModel
        {
            id = 7,
            name = "Best Friends Forever Magnetic Dress Up",
            price = (Decimal)24.95,
            availability = "InStock",
            stockAvailability = 10,
            age = "3_to_5",
            gender = "FEMALE",
            brand = "CoolKidz"
        };

        public ProductsModel _8_City_Garage_Truck_Lego = new ProductsModel
        {
            id = 8,
            name = "City Garage Truck Lego",
            price = (Decimal)19.95,
            availability = "",
            stockAvailability = 10,
            age = "3_to_5",
            gender = "NEUTRAL",
            brand = "Lego"
        };

        public ProductsModel _20_Creator_Beach_House_Lego = new ProductsModel
        {
            id = 20,
            name = "Creator Beach House Lego",
            price = (Decimal)39.95,
            availability = "",
            stockAvailability = 10,
            age = "6_to_8",
            gender = "NEUTRAL",
            brand = "Lego"
        };


        public DatabaseFixture()
        {
            DbContextOptions<ProductsContext> _productOptions = new DbContextOptionsBuilder<ProductsContext>().UseInMemoryDatabase("Products").Options;
            productContext = new ProductsContext(_productOptions);

            productContext.Products.Add(_1_Balance_Training_Bicycle);
            productContext.Products.Add(_2_43_Piece_dinner_Set);
            productContext.Products.Add(_7_Best_Friends_Forever_Magnetic_Dress_Up);
            productContext.Products.Add(_8_City_Garage_Truck_Lego);
            productContext.Products.Add(_20_Creator_Beach_House_Lego);

            productContext.SaveChanges();
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}

