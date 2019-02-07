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
    public class DefaultProductDatabaseFixture : AbstractDatabaseFixture
    {
        public override string GetDatabaseName() => "DefaultProductDatabaseCartsTest";
    }
    public class CartsServiceTest : IClassFixture<DefaultProductDatabaseFixture>
    {
        private const int DEFAULT_USER_ID = 1; 
        private ProductsContext _productContext;
        private DefaultProductDatabaseFixture _fixture;

        public CartsServiceTest(DefaultProductDatabaseFixture fixture)
        {
            _fixture = fixture;
            _productContext = fixture.productContext;
        }

        [Fact]
        public void When_Create_New_Cart_With_43_Piece_Dinner_Set_With_1_Qty_Should_Return_Cart_Detail_With_43_Piece_Dinner_Set ()
        {
            ProductsModel adding_product = _fixture._2_43_Piece_dinner_Set;
            int adding_quantity = 1;
            CartsContext _cartContext = createCartsContext("create_new_cart_carts2");
            CartsModel expectedCart = createCartInfo(adding_product, adding_quantity);

            CartsService cartService = new CartsService(_cartContext, _productContext);
            AddCartOutputModel cartOutput = cartService.add(adding_product, adding_quantity);
            CartsModel actualCart = cartService.getCart(cartOutput.id, DEFAULT_USER_ID);

            Assert.Equal(expectedCart.CartProducts, actualCart.CartProducts);
            Assert.Equal(expectedCart.userId, actualCart.userId);
            Assert.Equal(expectedCart.total, actualCart.total);
            Assert.Equal(expectedCart.subtotal, actualCart.subtotal);
            Assert.Equal(expectedCart.shippingFee, actualCart.shippingFee);
            Assert.Equal(expectedCart.shippingMethod, actualCart.shippingMethod);
        }

        private static CartsContext createCartsContext(string databaseName)
        {
            var _cartOptions = new DbContextOptionsBuilder<CartsContext>().UseInMemoryDatabase(databaseName).Options;
            var _cartContext = new CartsContext(_cartOptions);
            return _cartContext;
        }

        private CartsModel createCartInfo(ProductsModel adding_product, int adding_quantity)
        {
            CartsModel expectedCart = new CartsModel
            {
                userId = DEFAULT_USER_ID,
                total = 62.95M,
                subtotal = 12.95M,
                shippingFee = 50,
                shippingMethod = "Cash on Delivery",
                createDatetime = DateTime.Now,
                updateDatetime = DateTime.Now
            };

            List<ProductInCartModel> productsInCart = new List<ProductInCartModel>();
            productsInCart.Add(new ProductInCartModel
            {
                id = adding_product.id,
                name = adding_product.name,
                price = adding_product.price,
                availability = "InStock",
                stockAvailability = 10,
                age = adding_product.age,
                gender = adding_product.gender,
                brand = adding_product.brand,
                quantity = adding_quantity
            });

            expectedCart.CartProducts = productsInCart;
            return expectedCart;
        }
    }

}

