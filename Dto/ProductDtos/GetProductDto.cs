using System;
using ELSAPI.Entities;

namespace ELSAPI.Dto
{
    public class GetProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public int Discount { get; set; } 
        public Category Category { get; set; } 
        public string MainImageUrl { get; set; }        

    }
}