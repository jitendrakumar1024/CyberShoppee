using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using CyberShoppeeApi.CyberShoppeeRepository.CategoriesRepository;
using CyberShoppeeDataAccessLayer.CyberShoppeeContext;
using CyberShoppeeDataAccessLayer.Entity;

namespace CyberShoppeeApi.CyberShoppeeRepository.OrdersRepository
{

  
    public class OrderRepository : IOrderRepository
    {
        CyberShoppeeContext context = new CyberShoppeeContext();

        public IEnumerable<Order> GetAllOrders() 
        {

            var allOrders = context.Orders.ToList();
           
            if (allOrders == null)
            {
                throw new ProductDataUnavailableException("No Products Found");
            }
            return allOrders;   

        }
        public Order GetOrderById(int id)
        {
            var order =  context.Orders.Find(id);
            if (order == null) { 
            throw new OrderDataUnavailableException("No Orders Found");
            }
            return order;
        }

       
    }
}