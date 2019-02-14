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
        
        public CartsModel getCart(int cartId, int userId) {
            CartsModel cart = _context.Carts.Where(c => c.id == cartId).Where(c => c.userId == userId).FirstOrDefault();
            List<CartProductsModel> cartProducts = _context.CartProducts.Where(c => c.cartId == cartId).ToList();
            List<ProductInCartModel> productsInCart = this.getProductInCart(cart.id);
            cart.CartProducts = productsInCart;
            return cart;
        }

        public List<ProductInCartModel> getProductInCart(int cartId) {
            List<CartProductsModel> cartProducts = this.getCartProducts(cartId);
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
            return productsInCart;
        }

        public List<CartProductsModel> getCartProducts(int cartId) {
            List<CartProductsModel> cartProducts = _context.CartProducts.Where(c => c.cartId == cartId).ToList();
            return cartProducts;
        }
        public AddCartOutputModel add(ProductsModel product, int quantity) {
            CartsModel cartModel = this.createCart(1);
            CartProductsModel cartProductsModel = this.addProductToCart(cartModel, product, quantity);
            List<ProductInCartModel> productsInCart = this.getProductInCart(cartModel.id);
            cartModel = this.calculate(cartModel, productsInCart);
            _context.Carts.Update(cartModel);
            _context.SaveChanges();            
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

        private CartProductsModel addProductToCart(CartsModel cartModel, ProductsModel product, int quantity) {
           CartProductsModel cartProductModel = new CartProductsModel{
               cartId = cartModel.id,
               productId = product.id,
               quantity = quantity
           };
           _context.CartProducts.Add(cartProductModel);
           _context.SaveChanges();
            
           return cartProductModel;
        }

        public void applyCoupon(CartsModel cartModel, CouponModel coupon){
            List<ProductInCartModel> productsInCart = this.getProductInCart(cartModel.id);
            cartModel = this.calculate(cartModel, productsInCart, coupon);
            _context.Carts.Update(cartModel);
            _context.SaveChanges();  
        }

        public CartsModel calculate(CartsModel cart, List<ProductInCartModel> productsInCart, CouponModel coupon = null) {
            if (productsInCart.Count() == 0) 
                return cart; 
            
            decimal subtotal = 0;
            decimal total = 0;
            decimal shippingFee = 50;
            string shippingMethod = "Cash on Delivery";
            foreach (var productInCart in productsInCart)
            {
                subtotal += productInCart.price * productInCart.quantity;
            }
            
            if(coupon != null){
                cart.discountCode = coupon.code;
                cart.discount = (subtotal <= coupon.discount)? subtotal : coupon.discount;
                subtotal = (subtotal <= coupon.discount)? 0 : coupon.discount - subtotal;
            }

            total = subtotal + shippingFee;
            cart.subtotal = subtotal;
            cart.total = total;
            cart.shippingFee = shippingFee;
            cart.shippingMethod = shippingMethod;
            return cart;
        }
    }
}