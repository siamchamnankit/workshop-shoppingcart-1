using System.Collections.Generic;
using api.Models;

namespace api.Services
{
    public interface ICartsService
    {
        IEnumerable<CartsModel> list();
        AddCartOutputModel add(ProductsModel product, int quantity);
        CartsModel getCart(int cartId, int userId);

    }
}