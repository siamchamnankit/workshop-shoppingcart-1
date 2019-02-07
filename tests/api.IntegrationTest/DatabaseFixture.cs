using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.IntegrationTest.Fixtures;
using api.Models;
using api.Services;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Xunit;

namespace api.IntegrationTest
{

    public abstract class AbstractDatabaseFixture : IDisposable
    {
        public ProductsContext productContext;

        public abstract string GetDatabaseName();

        public AbstractDatabaseFixture()
        {
            DbContextOptionsBuilder<ProductsContext> builder = new DbContextOptionsBuilder<ProductsContext>();
            DbContextOptions<ProductsContext> _productOptions = builder.UseInMemoryDatabase(GetDatabaseName()).Options;
            productContext = new ProductsContext(_productOptions);

            productContext.Products.Add(_1_Balance_Training_Bicycle);
            productContext.Products.Add(_2_43_Piece_dinner_Set);
            productContext.Products.Add(_7_Best_Friends_Forever_Magnetic_Dress_Up);
            productContext.Products.Add(_8_City_Garage_Truck_Lego);
            productContext.Products.Add(_20_Creator_Beach_House_Lego);

            productContext.SaveChanges();
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public ProductsModel _1_Balance_Training_Bicycle = new ProductsModel
        {
            id = 1,
            name = "Balance Training Bicycle",
            price = (Decimal)119.95,
            availability = "InStock",
            stockAvailability = 1,
            age = "3_to_5",
            gender = "NEUTRAL",
            brand = "SportsFun"
        };

        public ProductsModel _2_43_Piece_dinner_Set = new ProductsModel
        {
            id = 2,
            name = "43 Piece dinner Set",
            price = (Decimal)12.95,
            availability = "InStock",
            stockAvailability = 10,
            age = "3_to_5",
            gender = "FEMALE",
            brand = "CoolKidz"
        };


        public ProductsModel _7_Best_Friends_Forever_Magnetic_Dress_Up = new ProductsModel
        {
            id = 7,
            name = "Best Friends Forever Magnetic Dress Up",
            price = (Decimal)24.95,
            availability = "InStock",
            stockAvailability = 10,
            age = "3_to_5",
            gender = "FEMALE",
            brand = "CoolKidz"
        };

        public ProductsModel _8_City_Garage_Truck_Lego = new ProductsModel
        {
            id = 8,
            name = "City Garage Truck Lego",
            price = (Decimal)19.95,
            availability = "",
            stockAvailability = 10,
            age = "3_to_5",
            gender = "NEUTRAL",
            brand = "Lego"
        };

        public ProductsModel _20_Creator_Beach_House_Lego = new ProductsModel
        {
            id = 20,
            name = "Creator Beach House Lego",
            price = (Decimal)39.95,
            availability = "",
            stockAvailability = 10,
            age = "6_to_8",
            gender = "NEUTRAL",
            brand = "Lego"
        };


    }
}
