using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using CyberShoppeeDataAccessLayer.CyberShoppeeContext;
using CyberShoppeeDataAccessLayer.Entity;

namespace CyberShoppeeApi.CyberShoppeeRepository.ProductsRepository
{
    public class ProductRepository : IProductRepository
    {
        CyberShoppeeContext context = new CyberShoppeeContext();
        public IEnumerable<Product> GetAllProducts()
        {
            var products = context.Products.ToList();

            if (products == null || !products.Any())
            {
                throw new ProductDataUnavailableException("No Products Found");
            }

            return products;
        }
        public Product GetProductById(int id)
        {
            var product = context.Products.FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                throw new ProductDataUnavailableException("No Product Found");
            }
            return product;
        }
        public Product GetProductByName(string name)
        {
            var product = context.Products.FirstOrDefault(p => p.ModelName == name);
            if (product == null)
            {
                throw new ProductDataUnavailableException($"No Product Found with the name : {name}");
            }
            return product;
        }

        public IEnumerable<Product> GetProductsByCategory(string categoryName)
        {
            var products = context.Products
                              .Where(p => p.Category.CategoryName == categoryName)
                              .ToList();

            if (products == null || !products.Any())
            {
                throw new ProductDataUnavailableException($"No products found for category: {categoryName}");
            }
            return products;
        }
    }
}