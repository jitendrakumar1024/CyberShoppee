using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;
using CyberShoppeeApi.CyberShoppeeRepository;
using CyberShoppeeApi.CyberShoppeeRepository.ProductsRepository;
using CyberShoppeeDataAccessLayer.CyberShoppeeContext;

namespace CyberShoppeeApi.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {
        private readonly IProductRepository _productRepository= new ProductRepository();

        [Route("")]

        public IHttpActionResult GetAllProductsDetails()
        {
            try
            {
                return Ok(_productRepository.getAllProduct());
            }
            catch (ProductDataUnavailableException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("id/{id}")]
        public IHttpActionResult GetCategoriesWiseProductDetail(int id)
        {
            try
            {
                var products = _productRepository.getProductByCategoriesName(id);
                return Ok(products);
            }
            catch (ProductDataUnavailableException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]  
        [Route("Search/{name}")]
        public IHttpActionResult GetProductByName( string name)
        {
            try
            {
                return Ok(_productRepository.getProductByProductsName(name));
            }
            catch (ProductDataUnavailableException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("LatestProducts")]
        public IHttpActionResult GetLeatestProduct()
        {
            try
            {
                return Ok(_productRepository.getTopProduct());
            }
            catch (ProductDataUnavailableException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
