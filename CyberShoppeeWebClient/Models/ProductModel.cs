using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CyberShoppeeDataAccessLayer.Entity;

namespace CyberShoppeeWebClient.Models
{
    public class ProductModel
    {
        public List<Product> Top10Products { get; set; }
        public List<Product> Mix10Products { get; set; }
        public List<Product> AllProducts { get; set; }
    }
}