using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CyberShoppeeDataAccessLayer.Entity;

namespace CyberShoppeeApi.CyberShoppeeRepository.ProductsRepository
{
    internal interface IProductRepository
    {
        IEnumerable<Product> getAllProduct();

        IEnumerable<Product> getProductByCategoriesName(int id);

        IEnumerable<Product> getProductByProductsName(string productName);

        IEnumerable<Product> getTopProduct();
    }
}
