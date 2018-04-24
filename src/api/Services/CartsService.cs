using System;
using System.Collections.Generic;
using System.Linq;
using api.Models;

namespace api.Services
{
    public class CartsService
    {
        private readonly CartsContext _context;
        private readonly ProductsContext _productContext;

        public CartsService(CartsContext context, ProductsContext productContext)
        {
            _context = context;
            _productContext = productContext;
        }

        internal IEnumerable<CartsModel> list()
        {
             return _context.Carts.ToList();
        }

        public CartsModel getCart(int cartId, int userId=1) {
            CartsModel cart = _context.Carts.Where(c => c.id == cartId).FirstOrDefault();
            List<CartProductsModel> cartProducts = _context.CartProducts.ToList();

            cart.CartProducts = cartProducts;

            return cart;
        }

        internal AddCartOutputModel add(int product_id, int quantity) {
            ProductsService productsService = new ProductsService(_productContext);
            ProductsModel productModel = productsService.getProductDetail(product_id);
            CartsModel cartModel = new CartsModel{
                userId = 1,
                subtotal = productModel.price * quantity,
                total = productModel.price * quantity,
                shippingMethod = "Cast on Delivery",
                shippingFee = 50,
                shippingId = 1,
                createDatetime = DateTime.Now,
                updateDatetime = DateTime.Now
            };
            _context.Carts.Add(cartModel);
            _context.SaveChanges();
            this.addCartProduct(cartModel.id, product_id, quantity);
            return new AddCartOutputModel{
                id = cartModel.id
            };
        }
        private CartProductsModel addCartProduct(int cartId, int productId, int quantity) {
           CartProductsModel cartProductModel = new CartProductsModel{
               cartId = cartId,
               productId = productId,
               quantity = quantity
           };
           _context.CartProducts.Add(cartProductModel);
           _context.SaveChanges();
           return cartProductModel;
        }
    }
}