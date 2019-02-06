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
    public class CartsTest
    {
        [Fact]
        public void When_Create_New_Cart_With_43_Piece_Dinner_Set_With_1_Qty_Should_Return_Cart_Detail_With_43_Piece_Dinner_Set () 
        {
            var _cartOptions = new DbContextOptionsBuilder<CartsContext>().UseInMemoryDatabase("create_new_cart_carts2").Options;
            var _cartContext = new CartsContext(_cartOptions);

            var _productOptions = new DbContextOptionsBuilder<ProductsContext>().UseInMemoryDatabase("create_new_cart_products2").Options;
            var _productContext = new ProductsContext(_productOptions);

            ProductsModel productsData = new ProductsModel{
                    id = 2,
                    name = "43 Piece dinner Set",
                    price = (Decimal)12.95,
                    availability = "InStock",
                    stockAvailability = 10,
                    age = "3_to_5",
                    gender = "FEMALE",
                    brand = "CoolKidz"
                };
            _productContext.Products.Add(productsData);
            _productContext.SaveChanges();

            CartsService cartService = new CartsService(_cartContext, _productContext);

            AddCartOutputModel cartOutput = cartService.add(productsData, 1);
            CartsModel actualCart = cartService.getCart(cartOutput.id, 1);
            CartsModel expectedCart = new CartsModel{
                userId = 1,
                total = 62.95M,
                subtotal = 12.95M,
                shippingFee = 50,
                shippingMethod = "Cash on Delivery",
                createDatetime = DateTime.Now,
                updateDatetime = DateTime.Now
            };

            List<ProductInCartModel> productsInCart = new List<ProductInCartModel>();
            productsInCart.Add(new ProductInCartModel{
                    id = 2,
                    name = "43 Piece dinner Set",
                    price = (Decimal)12.95,
                    availability = "InStock",
                    stockAvailability = 10,
                    age = "3_to_5",
                    gender = "FEMALE",
                    brand = "CoolKidz",
                    quantity = 1
                });

                expectedCart.CartProducts = productsInCart;

            Assert.Equal(expectedCart.CartProducts[0].name, actualCart.CartProducts[0].name);    


        }


        [Fact]
        public void When_Create_New_Cart_With_Product_ID2_And_Quantity2_And_Should_Be_Get_CartID1()
        {
            var _cartOptions = new DbContextOptionsBuilder<CartsContext>().UseInMemoryDatabase("create_new_cart_carts").Options;
            var _cartContext = new CartsContext(_cartOptions);

            var _productOptions = new DbContextOptionsBuilder<ProductsContext>().UseInMemoryDatabase("create_new_cart_products").Options;
            var _productContext = new ProductsContext(_productOptions);

            ProductsModel productsData = new ProductsModel{
                    id = 2,
                    name = "43 Piece dinner Set",
                    price = (Decimal)12.95,
                    availability = "InStock",
                    stockAvailability = 10,
                    age = "3_to_5",
                    gender = "FEMALE",
                    brand = "CoolKidz"
                };
            _productContext.Products.Add(productsData);
            _productContext.SaveChanges();

            CartsService cartsService = new CartsService(_cartContext, _productContext);
            var actualResult = cartsService.add(productsData, 1);

            Assert.Equal(1, actualResult.id);
        }

        [Fact]
        public void When_Calculate_Cart_With_One_Product_Price_119_95_Should_Be_Total_equal_169_95()
        {
            var _cartOptions = new DbContextOptionsBuilder<CartsContext>().UseInMemoryDatabase("calculate_carts").Options;
            var _cartContext = new CartsContext(_cartOptions);

            var _productOptions = new DbContextOptionsBuilder<ProductsContext>().UseInMemoryDatabase("calculate_products").Options;
            var _productContext = new ProductsContext(_productOptions);
            CartsModel cartModel = new CartsModel{
                userId = 1,
                createDatetime = DateTime.Now,
                updateDatetime = DateTime.Now
            };
            List<ProductInCartModel> productsInCart = new List<ProductInCartModel>();
            productsInCart.Add(new ProductInCartModel{
                price = (Decimal)119.95,
                quantity = 1
            });

            CartsService cartsService = new CartsService(_cartContext, _productContext);
            var actualResult = cartsService.calculate(cartModel, productsInCart);

            Assert.Equal((Decimal)119.95, actualResult.subtotal);
            Assert.Equal((Decimal)169.95, actualResult.total);
        }

        [Fact]
        public void When_Get_Cart_By_Id_1_And_Should_Be_Get_This_Cart_Detail()
        {
            var _cartOptions = new DbContextOptionsBuilder<CartsContext>().UseInMemoryDatabase("get_carts_carts_detail").Options;
            var _cartContext = new CartsContext(_cartOptions);

            var _productOptions = new DbContextOptionsBuilder<ProductsContext>().UseInMemoryDatabase("get_carts_carts_products_detail").Options;
            var _productContext = new ProductsContext(_productOptions);

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

            CartsService cartsService = new CartsService(_cartContext, _productContext);
            var actualResult = cartsService.getCart(1, 1);

            Assert.Equal(cartModel, actualResult);
        }
        [Fact]
        public void AddCartInputModel_should_be_correctly(){
            AddCartInputModel input = new AddCartInputModel{
                id = 1,
                quantity = 10
            };
            Assert.Equal(1, input.id);
            Assert.Equal(10, input.quantity);
        }
    }
}

