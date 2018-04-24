using System;
using System.Collections.Generic;
using System.Linq;
using api.Controllers;
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace api.UnitTest
{
    public class LoginControllerTest
    {
        [Fact]
        public void get_product_detail_by_id_return_product_detail(){

            // Arrange
            int product_id = 2;

            var mockService = new Mock<IProductService>();
            mockService.Setup(
                service => service.getProductDetail(product_id))
                .Returns(
                    new ProductsModel { id=2 , name= "43 Piece dinner Set", gender = "Female", age = "3_to_5",availability = "InStock" , brand = "CoolKidz"}
                );

            var controller = new ProductsController(mockService.Object);

            var expected_product = new ProductsModel{ id=2 , name= "43 Piece dinner Set", gender = "Female", age = "3_to_5",availability = "InStock" , brand = "CoolKidz"}; 

            //Act
            var result = controller.Get(product_id);

            // Assert
            var user = Assert.IsType<ProductsModel>(result);
            Assert.Equal("43 Piece dinner Set", user.name);
        }

    }
}
