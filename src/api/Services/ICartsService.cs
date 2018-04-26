using System.Collections.Generic;
using api.Models;

namespace api.Services
{
    public interface ICartsService
    {
        AddCartOutputModel add(ProductsModel product, int quantity);
        CartsModel getCart(int cartId, int userId);
    }
}