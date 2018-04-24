using System.Collections.Generic;
using api.Models;

namespace api.Services
{
    public interface IProductService
    {
        ProductsModel getProductDetail(int id);
        ProductsListModel list();
        IEnumerable<ProductsModel> list_products();

    }
}