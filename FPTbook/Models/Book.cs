using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FPTBook.Models
{
        public class Book
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public double Price { get; set; }
            public string Author { get; set; }
            public string Publisher { get; set; }
            public string Image { get; set; }
            public int CategoryId { get; set; }
            public int Quantity { get; set; }
            public string CategoryName { get; set; }
            public Category Category { get; set; }
            public ICollection<Order> Orders { get; set; }
        }
}



