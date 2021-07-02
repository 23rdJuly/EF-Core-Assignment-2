using System;
using System.Collections.Generic;
using System.Linq;
using EF_Core_2.Models;

namespace EF_Core_2.Services
{
    public class ProductService : IProductService
    {
        private ProductContext _productContext;

        public ProductService(ProductContext productContext)
        {
            _productContext = productContext;

        }
        public Product Get(int id) => _productContext.Products.Find(id);
        public List<Product> GetAll()
        {
            List<Product> products = _productContext.Products.ToList();
            return products;
        }

        public Product Create(ProductDTO product)
        {
            using var transaction = _productContext.Database.BeginTransaction();
            try{
                var newProduct = new Product
                {
                    ProductName = product.ProductName,
                    Manufacture = product.Manufacture,
                    CategoryId = product.CategoryId
                };
                _productContext.Products.Add(newProduct);
                _productContext.SaveChanges();
                transaction.Commit();
                return newProduct;
            }catch(Exception)
            {
                return null;
            }
        }

        public Product Edit(ProductDTO product, int id)
        { using var transaction = _productContext.Database.BeginTransaction();
            try{
                var existedProduct = Get(id);
                if (existedProduct != null)
                {
                    existedProduct.ProductName = product.ProductName;
                    existedProduct.Manufacture = product.Manufacture;
                    existedProduct.CategoryId = product.CategoryId;
                    _productContext.SaveChanges();
                    transaction.Commit();
                    return existedProduct;
                }
                else{
                    return null;
                }
               
            }catch(Exception)
            {
                return null;
            }
        }
        public void Delete(int id)
        {
            Product product = Get(id);
            _productContext.Products.Remove(product);
            _productContext.SaveChanges();
        }
    }
}