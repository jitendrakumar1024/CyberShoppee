using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CyberShoppeeDataAccessLayer.CyberShoppeeContext;
using CyberShoppeeDataAccessLayer.Entity;

namespace CyberShoppeeApi.CyberShoppeeRepository.CategoriesRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        CyberShoppeeContext context = new CyberShoppeeContext();

        public IEnumerable<Category> GetAllCategories()
        {
            var categories = context.Categories.ToList();
            if (categories == null) { 
            throw new CategoriesDataUnavailableException("No Categories Found");
            }
            return categories;
        }


        //public IEnumerable<Category> GetCategoriesByProducts(int id)
        //{
        //    var products = context.Products.Where(c => c.CategoryId == id).ToList();
        //    if (products == null)
        //    {
        //        throw new ProductDataUnavailableException("product not found");
        //    }
        //    return products;
        //}


    }
}