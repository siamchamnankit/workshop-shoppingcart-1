using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using api.Models;
using api.Services;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Xunit;

namespace api.IntegrationTest
{
    public class CartsTest
    {   
        
        CartsService _cartsService;
        private CartsModel _cartModel;
        private List<ProductInCartModel> _productsInCart;

        public CartsTest(){
            _cartModel = new CartsModel();
            _cartsService = new CartsService(null, null);

            _productsInCart= new List<ProductInCartModel>();
        }

        [Fact]
        public void When_Calculate_Cart_With_Zero_Product_Should_Be_Total_equal_0()
        {
            var actualResult = _cartsService.calculate(_cartModel, _productsInCart);

            Assert.Equal(0.00M, actualResult.total);
        }

        [Theory]
        [InlineData(0, 1 ,50.00)]
        [InlineData(119.95, 1 ,169.95)]
        [InlineData(119.95, 2 ,289.90)]
        public void When_Calculate_Only_One_Product_Cart_Total_Should_be_Add_Shipping_fee(decimal price, int quantity, decimal expectTotal)
        {
            _productsInCart.Add(new ProductInCartModel{price = price, quantity = quantity});

            var actualResult = _cartsService.calculate(_cartModel, _productsInCart);

            Assert.Equal(expectTotal, actualResult.total);
        }

        [Fact]
        public void When_Calculate_Cart_With_Two_Products_Price_12_95_and_110_95_Should_Be_Total_equal_173_90()
        {
            _productsInCart.Add(new ProductInCartModel{price = 12.95M, quantity = 1});
            _productsInCart.Add(new ProductInCartModel{price = 110.95M,quantity = 1});

            var actualResult = _cartsService.calculate(_cartModel, _productsInCart);
    
            Assert.Equal(173.90M, actualResult.total);
        }

        [Fact]
        public void When_Calculate_Cart_With_Two_Products_Price_12_95_And_24_95_With_2_Items_Should_Be_Total_equal_125_80()
        {
            _productsInCart.Add(new ProductInCartModel{price = 12.95M, quantity = 2});
            _productsInCart.Add(new ProductInCartModel{price = 24.95M, quantity = 2});

            var actualResult = _cartsService.calculate(_cartModel, _productsInCart);

            Assert.Equal(125.80M, actualResult.total);
        }

        [Fact]
        public void When_Calculate_Cart_With_Products_Price_150_And_Apply_Coupon_200_Should_Be_Total_equal_50()
        {
            _productsInCart.Add(new ProductInCartModel{price = 150.00M, quantity = 1});
            
            CouponModel coupon = new CouponModel{
                code = "VALENTINE200",
                discount = 200.00M,
                min_spending = 150,
                limit = 100,
                count = 50,
            };

            var actualResult = _cartsService.calculate(_cartModel, _productsInCart, coupon);

            Assert.Equal(50M, actualResult.total);
        }


      
    }
}

