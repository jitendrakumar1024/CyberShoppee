using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CyberShoppeeDataAccessLayer.Entity;
namespace CyberShoppeeApi.CyberShoppeeRepository.CategoriesRepository
{
    public interface ICategoryRepository
    {
         IEnumerable<Category> GetAllCategories();
         Category GetCategoryById(int id);
        Category GetCategoryByName(string name);

    }
}
