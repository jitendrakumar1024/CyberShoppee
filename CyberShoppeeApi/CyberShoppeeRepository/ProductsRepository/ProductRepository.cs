using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CyberShoppeeDataAccessLayer.CyberShoppeeContext;
using CyberShoppeeDataAccessLayer.Entity;

namespace CyberShoppeeApi.CyberShoppeeRepository.ProductsRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly CyberShoppeeContext cyberShoppeeContext = new CyberShoppeeContext();
        public IEnumerable<Product> getAllProduct()
        {
            var products = cyberShoppeeContext.Products.ToList();
            if (products == null)
            {
                throw new ProductDataUnavailableException("Product not found");
            }
            return products;
        }

        public IEnumerable<Product> getLatestProduct()
        {
            var products=cyberShoppeeContext.Products.OrderBy(r => Guid.NewGuid()).Take(10).ToList(); 
            if (products == null)
            {
                throw new ProductDataUnavailableException("product not available");
            }
            return products;
        }

        public IEnumerable<Product> getProductByCategoriesName(int id)
        {
            var products = cyberShoppeeContext.Products.Where(c => c.CategoryId == id).ToList();
            if (products == null)
            {
                throw new ProductDataUnavailableException("product not found");
            }
            return products;
        }

        public Product getProductById(int id)
        {
            if (id == 0)
            {
                throw new ProductDataUnavailableException("Product Id not found");
            }
            else
            {
                var product = cyberShoppeeContext.Products.Find(id);
                if (product == null)
                {
                    throw new ProductDataUnavailableException("Product not found");
                }
                return product;
            }
        }

        public IEnumerable<Product> getProductByProductsName(string name)
        {
            var products = cyberShoppeeContext.Products.Where(p => p.ModelName.Contains(name)).ToList();
            if (products == null)
            {
                throw new ProductDataUnavailableException("Product not found");
            }
            return products;
        }

        public IEnumerable<Product> getTopProduct()
        {
            var topProducts = cyberShoppeeContext.Products.OrderByDescending(c => c.ProductId).Take(10).ToList();
            if (topProducts == null)
            {
                throw new ProductDataUnavailableException("Latest Product not found ");
            }
            return topProducts;
        }
    }
}