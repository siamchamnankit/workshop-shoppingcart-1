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
    public class OrdersServiceTest
    {
        [Fact]
        public void When_Create_Order_With_Cart_Should_Be_Return_Order()
        {
            var _productContext = new DatabaseProductDummy().productContext;

            OrdersContext _orderContext = generateOrderContext("create_order_orders_2");

            CartsContext _cartContext = generateCartContext("create_order_carts_detail_2");

            OrdersModel ordersModel = new OrdersModel{
                cartId = 1,
                userId = 1,
                subtotal = (Decimal)12.95,
                total = (Decimal)62.95,
                shippingMethod = "Cash on Delivery",
                shippingFee = 50,
                fullname = "Chonnikan Tobunrueang",
                address1 = "3 อาคารพร้อมพันธ์ 3 ห้อง 1001",
                address2 = "จอมพล",
                city = "จตุจักร",
                province = "กรุงเทพ",
                postcode = "10900",
                createDatetime = DateTime.Now,
            };

            OrderProductsModel orderProductsModel = new OrderProductsModel{
                orderId = 1,
                productId = 2,
                quantity = 1,
                name = "43 Piece dinner Set",
                price = (Decimal)12.95,
                availability = "InStock",
                stockAvailability = 10,
                age = "3_to_5",
                gender = "FEMALE",
                brand = "CoolKidz"
            };

            OrderDetailOutput expectedResult = new OrderDetailOutput{
                order = ordersModel,
                products = new ProductsListOutput{
                    total = 1,
                    data = new List<OrderProductsModel>(){
                        orderProductsModel
                    },
                }
            };

            OrdersService ordersService = new OrdersService(_cartContext, _productContext, _orderContext);
            CreateOrderOutputModel order = ordersService.create(1, 1);
            
            var actual = ordersService.get(order.id);

            Assert.Equal(order.id, actual.order.id);
            Assert.Equal(expectedResult.order.subtotal, actual.order.subtotal);
            Assert.Equal(expectedResult.order.total, actual.order.total);
            Assert.Equal(expectedResult.order.shippingMethod, actual.order.shippingMethod);
            Assert.Equal(expectedResult.order.shippingFee, actual.order.shippingFee);
            Assert.Equal(expectedResult.order.fullname, actual.order.fullname);
            Assert.Equal(expectedResult.order.address1, actual.order.address1);
            Assert.Equal(expectedResult.products.data, actual.products.data);


            _productContext.Database.EnsureDeleted();
            _cartContext.Database.EnsureDeleted();
            _orderContext.Database.EnsureDeleted();
        }

        private static OrdersContext generateOrderContext(string orderDatabaseName)
        {
            var _orderOptions = new DbContextOptionsBuilder<OrdersContext>().UseInMemoryDatabase(orderDatabaseName).Options;
            var _orderContext = new OrdersContext(_orderOptions);
            return _orderContext;
        }

        private static CartsContext generateCartContext(string databaseName)
        {
            var _cartOptions = new DbContextOptionsBuilder<CartsContext>().UseInMemoryDatabase(databaseName).Options;
            var _cartContext = new CartsContext(_cartOptions);


            CartsModel cartModel = new CartsModel
            {
                id = 1,
                userId = 1,
                shippingMethod = "Cash on Delivery",
                subtotal = (Decimal)12.95,
                shippingFee = (Decimal)50.00,
                total = (Decimal)62.95
            };
            _cartContext.Carts.Add(cartModel);

            CartProductsModel cartProduct = new CartProductsModel
            {
                id = 1,
                productId = 2,
                cartId = 1,
                quantity = 1,
            };
            _cartContext.CartProducts.Add(cartProduct);
            _cartContext.SaveChanges();
            return _cartContext;
        }
    }
}

