using System;
using System.Collections.Generic;
using System.Linq;

namespace ELSAPI.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public int Discount { get; set; } = 0;
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public List<ProductColor> Colors { get; set; }
        
    }
}