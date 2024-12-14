using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CyberShoppeeApi.CyberShoppeeRepository.CustomersRepository;
using CyberShoppeeApi.CyberShoppeeRepository;
using CyberShoppeeApi.CyberShoppeeRepository.ProductsRepository;
using System.Xml.Linq;

namespace CyberShoppeeApi.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {

        private IProductRepository _ProductRepository = new ProductRepository();
        // route for getting all product details in a list
        [Route("")]
        public IHttpActionResult GetAllProducts()
        {
            try
            {
                return Ok(_ProductRepository.GetAllProducts());
            }
            catch (ProductDataUnavailableException e)
            {
                return BadRequest(e.Message);
            }

        }
        // route for getting all product details by product id
        [Route("{id}")]
        public IHttpActionResult GetProductById(int id)
        {
            try
            {
                return Ok(_ProductRepository.GetProductById(id));
            }
            catch (ProductDataUnavailableException e)
            {
                return BadRequest(e.Message);
            }
        }
        // route for getting all product details by product name
        [Route("name/{name}")]
        public IHttpActionResult GetProductByName(string name)
        {
            try
            {
                return Ok(_ProductRepository.GetProductByName(name));
            }
            catch (ProductDataUnavailableException e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        [Route("category/{categoryName}")]
        public IHttpActionResult GetProductsByCategory(string categoryName)
        {
            try
            {
                return Ok(_ProductRepository.GetProductsByCategory(categoryName));
            }
            catch (ProductDataUnavailableException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
