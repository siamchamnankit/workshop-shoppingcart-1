using System;
using System.Collections.Generic;
using System.Linq;
using api.Models;

namespace api.Services
{
    public class CartsService : ICartsService
    {
        private readonly CartsContext _context;
        private readonly ProductsContext _productContext;

        public CartsService(CartsContext context, ProductsContext productContext)
        {
            _context = context;
            _productContext = productContext;
        }

        public IEnumerable<CartsModel> list()
        {
             return _context.Carts.ToList();
        }
        public CartsModel getCart(int cartId, int userId=1) {
            CartsModel cart = _context.Carts.Where(c => c.id == cartId).Where(c => c.userId == userId).FirstOrDefault();
            List<CartProductsModel> cartProducts = _context.CartProducts.Where(c => c.cartId == cartId).ToList();
            List<ProductInCartModel> productsInCart = new List<ProductInCartModel>();
            foreach (CartProductsModel cartProduct in cartProducts)
            {
                ProductsModel product = _productContext.Products.Where(p => p.id == cartProduct.productId).FirstOrDefault();
                productsInCart.Add(new ProductInCartModel{
                    id = product.id,
                    name = product.name,
                    price = product.price,
                    availability = product.availability,
                    stockAvailability = product.stockAvailability,
                    age = product.age,
                    gender = product.gender,
                    brand = product.brand,
                    quantity = cartProduct.quantity
                });
            }
            cart.CartProducts = productsInCart;
            return cart;
        }
        public AddCartOutputModel add(ProductsModel product, int quantity) {
            CartsModel cartModel = this.createCart(1);
            this.addProductToCart(cartModel, product, quantity);
            return new AddCartOutputModel{
                id = cartModel.id
            };
        }

        private CartsModel createCart(int user_id){
            CartsModel cartModel = new CartsModel{
                userId = user_id,
                createDatetime = DateTime.Now,
                updateDatetime = DateTime.Now
            };
            _context.Carts.Add(cartModel);
            _context.SaveChanges();
            return cartModel;
        }

        private void calculateCart(CartsModel cartModel) {
            List<CartProductsModel> _cartproducts = cartModel.CartProducts.ToList();
            foreach (CartProductsModel product in _cartproducts) {
                Console.WriteLine(product.id);
            }
        }
        private CartProductsModel addProductToCart(CartsModel cartModel, ProductsModel product, int quantity) {
           CartProductsModel cartProductModel = new CartProductsModel{
               cartId = cartModel.id,
               productId = product.id,
               quantity = quantity
           };
           _context.CartProducts.Add(cartProductModel);
           _context.SaveChanges();

            cartModel.shippingFee = 50;
            cartModel.shippingMethod = "Cast on Delivery";
            cartModel.subtotal = product.price * quantity;
            cartModel.total = (product.price * quantity)+50;
            _context.Carts.Update(cartModel);
            _context.SaveChanges();
            
           return cartProductModel;
        }
    }
}