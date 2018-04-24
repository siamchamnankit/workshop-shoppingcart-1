using System;
using System.Collections.Generic;
using System.Linq;
using api.Controllers;
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace api.UnitTest
{
    public class CartsTest
    {
        [Fact]
        public void add_product_to_cart_return_cart_id(){
            int product_id = 1;
            int quantity = 10;
            var mockCartService = new Mock<ICartsService>();
            var mockProductService = new Mock<IProductService>();
            var product = new ProductsModel { id=1 , name= "43 Piece dinner Set", gender = "Female", age = "3_to_5",availability = "InStock" , brand = "CoolKidz"};
            mockProductService.Setup(
                service => service.getProductDetail(product_id))
                .Returns(
                    product
                );
            mockCartService.Setup(
                service => service.add(product, quantity))
                .Returns(new AddCartOutputModel{
                    id = 1
                });

            CartsController cartsController = new CartsController(mockCartService.Object, mockProductService.Object);
            AddCartInputModel input = new AddCartInputModel{
                id = product_id,
                quantity = quantity
            };
            JsonResult result = cartsController.Post(input) as JsonResult;
            var json = JsonConvert.SerializeObject(result.Value); 
            var cart =  JsonConvert.DeserializeObject<AddCartOutputModel>(json);
            Assert.Equal(1, cart.id);
        }

    }
}
