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

            var _orderOptions = new DbContextOptionsBuilder<OrdersContext>().UseInMemoryDatabase("create_order_orders_1").Options;
            var _orderContext = new OrdersContext(_orderOptions);

            var _cartOptions = new DbContextOptionsBuilder<CartsContext>().UseInMemoryDatabase("create_order_carts_detail_1").Options;
            var _cartContext = new CartsContext(_cartOptions);

            var _productOptions = new DbContextOptionsBuilder<ProductsContext>().UseInMemoryDatabase("create_order_carts_products_detail_1").Options;
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

            OrdersService ordersService = new OrdersService(_cartContext, _productContext, _orderContext);
            var actualResult = ordersService.create(1, 1);

            //  CreateOrderOutputModel actualResult = new CreateOrderOutputModel{
            //     id = 1
            //  };

            Assert.Equal(2, actualResult.id);

            
            
            using (var context = new ProductsContext(_productOptions))
            {
                _productContext.Database.EnsureDeleted();
            }
            using (var context = new CartsContext(_cartOptions))
            {
                _cartContext.Database.EnsureDeleted();
            }
            using (var context = new OrdersContext(_orderOptions))
            {
                _orderContext.Database.EnsureDeleted();
            }
        }

        [Fact]
        public void When_Get_Order_Id_1_Should_Be_Return_Only_This_Order() 
        {
            var _orderOptions = new DbContextOptionsBuilder<OrdersContext>().UseInMemoryDatabase("create_order_orders_detail_2").Options;
            var _orderContext = new OrdersContext(_orderOptions);

            var _cartOptions = new DbContextOptionsBuilder<CartsContext>().UseInMemoryDatabase("create_order_carts_detail_2").Options;
            var _cartContext = new CartsContext(_cartOptions);

            var _productOptions = new DbContextOptionsBuilder<ProductsContext>().UseInMemoryDatabase("create_order_carts_products_detail_2").Options;
            var _productContext = new ProductsContext(_productOptions);
            
            OrdersModel ordersModel = new OrdersModel{
                cartId = 1,
                userId = 1,
                subtotal = (Decimal)25.90,
                total = (Decimal)75.90,
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
            _orderContext.Orders.Add(ordersModel);
           
           OrderProductsModel orderProductsModel = new OrderProductsModel{
                orderId = 1,
                productId = 2,
                quantity = 2,
                name = "43 Piece dinner Set",
                price = (Decimal)12.95,
                availability = "InStock",
                stockAvailability = 10,
                age = "3_to_5",
                gender = "FEMALE",
                brand = "CoolKidz"
            };
            _orderContext.OrderProducts.Add(orderProductsModel);

            _orderContext.SaveChanges();

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
            var actual = ordersService.get(1);
            
            Assert.Equal(expectedResult.order.id, actual.order.id);
            
            using (var context = new ProductsContext(_productOptions))
            {
                _productContext.Database.EnsureDeleted();
            }
            using (var context = new CartsContext(_cartOptions))
            {
                _cartContext.Database.EnsureDeleted();
            }
            using (var context = new OrdersContext(_orderOptions))
            {
                _orderContext.Database.EnsureDeleted();
            }
        }
    }
}

