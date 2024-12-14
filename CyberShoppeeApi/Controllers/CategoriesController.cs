using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CyberShoppeeApi.CyberShoppeeRepository;
using CyberShoppeeApi.CyberShoppeeRepository.CategoriesRepository;

namespace CyberShoppeeApi.Controllers
{
    [RoutePrefix("api/categories")]
    public class CategoriesController : ApiController
    {
        private ICategoryRepository _categoryRepository = new CategoryRepository();
        [Route("")]
        public IHttpActionResult GetAllCategories()
        {
            try
            {
                return Ok(_categoryRepository.GetAllCategories());
            } 
            catch(CategoriesDataUnavailableException e) 
            { 
                return BadRequest(e.Message);
            }
        }
        [Route("{id}")]
        public IHttpActionResult GetCategoryById(int id)
        {
            try {
                return Ok(_categoryRepository.GetCategoryById(id));
            }
            catch(CategoriesDataUnavailableException e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("name/{name}")]
        public IHttpActionResult GetCategoryByName(string name)
        {
            try
            {
                return Ok(_categoryRepository.GetCategoryByName(name));
            }
            catch (CategoriesDataUnavailableException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
