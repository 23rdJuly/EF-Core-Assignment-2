using System.Collections.Generic;
using EF_Core_2.Models;

namespace EF_Core_2.Services
{
    public interface IProductService{
        List<Product> GetAll();
        Product Edit(ProductDTO product, int id);
        Product Get(int id);
        Product Create(ProductDTO product);
        void Delete(int id);
    }
}