using System;
using System.Collections.Generic;
using System.Linq;
using api.Models;

namespace api.Services
{
    public class OrdersService
    {
        private readonly CartsContext _cartContext;
        
        private readonly ProductsContext _productContext;
        private readonly OrdersContext _orderContext;

        public OrdersService(CartsContext cartContext, ProductsContext productContext, OrdersContext orderContext)
        {
            _cartContext = cartContext;
            _productContext = productContext;
            _orderContext = orderContext;
        }

        public CreateOrderOutputModel create(int cartId, int userId = 1) {
            CartsService cartsService = new CartsService(_cartContext, _productContext);
            CartsModel cart = cartsService.getCart(cartId, userId);
            OrdersModel order = new OrdersModel{
                cartId = cart.id,
                userId = userId,
                subtotal = cart.subtotal,
                total = cart.total,
                shippingMethod = cart.shippingMethod,
                shippingFee = cart.shippingFee,
                fullname = "Chonnikan Tobunrueang",
                address1 = "3 อาคารพร้อมพันธ์ 3 ห้อง 1001",
                address2 = "จอมพล",
                city = "จตุจักร",
                province = "กรุงเทพ",
                postcode = "10900",
                createDatetime = DateTime.Now,
            };
            _orderContext.Orders.Add(order);
            _orderContext.SaveChanges();

            List<CartProductsModel> cartProducts = _cartContext.CartProducts.Where(c => c.cartId == cartId).ToList();
            List<OrderProductsModel> orderProducts = new List<OrderProductsModel>();
            foreach (CartProductsModel cartProduct in cartProducts)
            {
                ProductsModel product = _productContext.Products.Where(p => p.id == cartProduct.productId).FirstOrDefault();
                _orderContext.OrderProducts.Add(new OrderProductsModel{
                    orderId = order.id,
                    productId = product.id,
                    quantity = cartProduct.quantity,
                    name = product.name,
                    price = product.price,
                    availability = product.availability,
                    stockAvailability = product.stockAvailability,
                    age = product.age,
                    gender = product.gender,
                    brand = product.brand
                });
            }
            
            _orderContext.SaveChanges();

            return new CreateOrderOutputModel{id = order.id};
        }

        public OrderDetailOutput get(int id) {
            var orderDetail = _orderContext.Orders.Where(m => m.id == id).FirstOrDefault();
            var orderProducts = _orderContext.OrderProducts.Where(m => m.orderId == id).ToList();
            OrderDetailOutput orderDetailOutput = new OrderDetailOutput{
                order =  orderDetail,
                products = new ProductsListOutput{
                    total = orderProducts.Count(),
                    data = orderProducts
                }
            };
            return orderDetailOutput;
        }
    }
}