using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CyberShoppeeDataAccessLayer.Entity;

namespace CyberShoppeeApi.CyberShoppeeRepository.CustomersRepository
{
    public interface ICustomerRepository
    {
         IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);

        string Register(Customer customer);

        string DeleteAccount(int id);
    }
}
