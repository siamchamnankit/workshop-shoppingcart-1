using System;
using System.Collections.Generic;
using System.Linq;
using api.Models;

namespace api.Services
{
    public class CartsService
    {
        private readonly CartsContext _context;

        public CartsService(CartsContext context)
        {
            _context = context;
        }

        internal IEnumerable<CartsModel> list()
        {
             return _context.Carts.ToList();
        }

        internal AddCartOutputModel add(int product_id, int quantity) {
            CartsModel cartModel = new CartsModel{
                userId = 1,
                subtotal = 10,
                total = 10,
                shippingMethod = "OK",
                shippingFee = 50,
                shippingId = 1,
                createDatetime = DateTime.Now,
                updateDatetime = DateTime.Now
            };
            _context.Carts.Add(cartModel);
            _context.SaveChanges();
            return new AddCartOutputModel{
                id = cartModel.id
            };
        }
    }
}