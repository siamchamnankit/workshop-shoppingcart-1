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
    public class DatabaseListFixture : AbstractDatabaseFixture
    {
        public override string GetDatabaseName() => "DatabaseListFixture";
    }

    public class ProductsListTest : IClassFixture<DatabaseListFixture>
    {
        private DatabaseListFixture _fixture;
        private ProductsService _productsService;

        public ProductsListTest(DatabaseListFixture fixture)
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
        public void When_Filter_age_Is_3_to_5_And_gender_Is_female_Then_Show_Filtered_Products_And_Total()
        {
            var expectedResult = new List<ProductsModel>();
            expectedResult.Add(_fixture._2_43_Piece_dinner_Set);
            expectedResult.Add(_fixture._7_Best_Friends_Forever_Magnetic_Dress_Up);

            var actualResult = _productsService.list("3_to_5", "FEMALE");

            Assert.Equal(2, actualResult.total);
            Assert.Equal(expectedResult, actualResult.ProductsModel);
        }

        [Fact]
        public void When_Filter_age_Is_3_to_5_Then_Show_Filtered_Products_And_Total_is_4()
        {
            var expectedResult = new List<ProductsModel>();
            expectedResult.Add(_fixture._1_Balance_Training_Bicycle);
            expectedResult.Add(_fixture._2_43_Piece_dinner_Set);
            expectedResult.Add(_fixture._7_Best_Friends_Forever_Magnetic_Dress_Up);
            expectedResult.Add(_fixture._8_City_Garage_Truck_Lego);

            var actualResult = _productsService.list("3_to_5");

            Assert.Equal(4, actualResult.total);
            Assert.Equal(expectedResult, actualResult.ProductsModel);
        }

        [Fact]
        public void When_Filter_gender_Is_female_Then_Show_Filtered_Products_And_Total_is_2()
        {
            var expectedResult = new List<ProductsModel>();
            expectedResult.Add(_fixture._2_43_Piece_dinner_Set);
            expectedResult.Add(_fixture._7_Best_Friends_Forever_Magnetic_Dress_Up);

            var actualResult = _productsService.list("", "FEMALE");

            Assert.Equal(2, actualResult.total);
            Assert.Equal(expectedResult, actualResult.ProductsModel);
        }

        [Fact]
        public void When_Filter_Age_Is_3_to_5_And_Gender_Is_Male_Then_Empty_List_And_Total_is_0()
        {
            var expectedResult = new List<ProductsModel>();

            var actualResult = _productsService.list("3_to_5", "MALE");

            Assert.Equal(0, actualResult.total);
            Assert.Equal(expectedResult, actualResult.ProductsModel);
        }    
    }

}

