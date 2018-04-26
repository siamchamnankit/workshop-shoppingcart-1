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
    public class OrdersTest
    {
        [Fact]
        public void When_Create_Order_With_Cart_Should_Be_Return_Order()
        {

            var _orderOptions = new DbContextOptionsBuilder<OrdersContext>().UseInMemoryDatabase("orders").Options;
            var _orderContext = new OrdersContext(_orderOptions);

            var _cartOptions = new DbContextOptionsBuilder<CartsContext>().UseInMemoryDatabase("carts_detail").Options;
            var _cartContext = new CartsContext(_cartOptions);

            var _productOptions = new DbContextOptionsBuilder<ProductsContext>().UseInMemoryDatabase("carts_products_detail").Options;
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
            
            CartsModel cartModel = new CartsModel{
                id = 1,
                userId = 1,
                subtotal = (Decimal)12.95,
                shippingFee = (Decimal)50.00,
                total = (Decimal)62.95
            };
            _cartContext.Carts.Add(cartModel);

            CartProductsModel cartProduct = new CartProductsModel{
                id = 1,
                productId = 2,
                cartId = 1,
                quantity = 1,
            };
            _cartContext.CartProducts.Add(cartProduct);
            _cartContext.SaveChanges();

            CreateOrderOutputModel orderExpected = new CreateOrderOutputModel{
                id = 1
            };

            OrdersService ordersService = new OrdersService(_cartContext, _productContext, _orderContext);
            var actualResult = ordersService.create(1, 1);

            Assert.Equal(orderExpected.id, actualResult.id);
        }
    }
}

