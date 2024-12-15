﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CyberShoppeeWebClient.Models
{
    public class OrderModel
    {
       public int OrderId { get; set; }
       public int CustomerId { get; set; }
       public DateTime OrderDate { get; set; }
       public DateTime ShipDate { get; set; }
    }
}
