using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
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


        public Category GetCategoryById(int id)
        {
            var category = context.Categories.FirstOrDefault(c => c.CategoryId == id);
            if (category == null)
            {
                throw new CategoriesDataUnavailableException("Haha - No Categories Found");
            }
            return category;
        }
        public Category GetCategoryByName(string name)
        {
            var category = context.Categories.FirstOrDefault(c => c.CategoryName == name);
            if (category == null)
            {
                throw new CategoriesDataUnavailableException("Haha - Category Not Found");
            }
            return category;
        }

    }
}