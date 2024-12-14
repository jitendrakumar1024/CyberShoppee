using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CyberShoppeeApi.CyberShoppeeRepository;
using CyberShoppeeApi.CyberShoppeeRepository.CustomersRepository;
using CyberShoppeeDataAccessLayer.Entity;

namespace CyberShoppeeApi.Controllers

{
    [RoutePrefix("api/customers")]
    public class CustomersController : ApiController
    {
        private ICustomerRepository _customerRepository = new CustomerRepository();


        // route for getting all product details in a list
        [Route("")]
        public IHttpActionResult GetAllCustomers()
        {
            try { 
                return Ok(_customerRepository.GetAllCustomers());
            }
            catch(CutomerDataUnavailableException e) {
                return BadRequest(e.Message); 
            }

        }
        [Route("{id}")]
        public IHttpActionResult GetCustomerById(int id) {
            try
            {
                return Ok(_customerRepository.GetCustomerById(id));
            }
            catch (CutomerDataUnavailableException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("Register")]

        public IHttpActionResult RegisterCustomer(Customer customer)
        {
            try
            {
                return Ok(_customerRepository.Register(customer));
            }
            catch (CutomerDataUnavailableException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("AccountDelete/{id}")]
        public IHttpActionResult DeleteCustomer(int id)
        {
            try
            {
                return Ok(_customerRepository.DeleteAccount(id));
            }
            catch(CutomerDataUnavailableException ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
