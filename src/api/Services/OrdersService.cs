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
            return new CreateOrderOutputModel{id = order.id};
        }
    }
}