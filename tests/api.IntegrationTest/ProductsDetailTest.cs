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
    public class DatabaseDetailFixture : AbstractDatabaseFixture
    {
        public override string GetDatabaseName() => "DatabaseDetailFixture";
    }

    public class ProductsDetailTest : IClassFixture<DatabaseDetailFixture>
    {
        private DatabaseDetailFixture _fixture;
        private ProductsService _productsService;

        public ProductsDetailTest(DatabaseDetailFixture fixture)
        {
            this._fixture = fixture;

            _productsService = new ProductsService(fixture.productContext);
        }


        [Fact]
        public void When_Get_Product_With_Id_2_Then_Show_Only_This_Product()
        {
            var actualResult = _productsService.getProductDetail(2);
            Assert.Equal(_fixture._2_43_Piece_dinner_Set, actualResult);
        }

        [Fact]
        public void When_Get_Not_Found_Product_At_22_Then_Should_Be_Null()
        {
            var actualResult = _productsService.getProductDetail(22);
            Assert.Null(actualResult);
        }
    }

}
