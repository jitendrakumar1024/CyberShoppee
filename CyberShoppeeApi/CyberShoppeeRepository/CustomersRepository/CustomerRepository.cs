using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using CyberShoppeeDataAccessLayer.CyberShoppeeContext;
using CyberShoppeeDataAccessLayer.Entity;

namespace CyberShoppeeApi.CyberShoppeeRepository.CustomersRepository
{
    public class CustomerRepository : ICustomerRepository
    {
        CyberShoppeeContext context = new CyberShoppeeContext();

        public Customer GetCustomerById(int id)
        {
            var customer = context.Customers.Find(id);
            if (customer == null)
            {
                throw new CutomerDataUnavailableException("No Customers Found");
            }
            return customer;


           
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            var customers = context.Customers.ToList();
            if (customers == null)
            {
                throw new CutomerDataUnavailableException("No Customers Found");
            }
            return customers; 
        }


        public string Register(Customer customer)
        {
            // Check if the customer with the same email already exists
            var existingCustomer = context.Customers.Any(c => c.EmailAddress == customer.EmailAddress);
            if (existingCustomer)
            {
                throw new CutomerDataUnavailableException("Email already registered");
            }
            else
            {
                if (customer.Password.Length > 8)
                {
                    var model = new Customer();
                    // Create new customer
                    model.FullName = customer.FullName;
                    model.EmailAddress = customer.EmailAddress;
                    model.DeliveryAddress = customer.DeliveryAddress;
                    model.Password = customer.Password;
                    context.Customers.Add(model);
                    context.SaveChanges();
                }
                else
                {
                    throw new CutomerDataUnavailableException("Password Length less than 8 character!!!");
                }
            };

            // Add new customer to context and save changes

            return "Registered Successfully";
        }

        public string DeleteAccount(int id)
        {
            var customer = context.Customers.Find(id);
            if(customer == null)
            {
                throw new CutomerDataUnavailableException("Customer Not found");
            }

            context.Customers.Remove(customer);
            context.SaveChanges();
            return "Customer Account deleted Successfully";
        }
    }
}