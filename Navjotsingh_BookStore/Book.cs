﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Navjotsingh_BookStore
{
    public class Book  
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        
    }
}