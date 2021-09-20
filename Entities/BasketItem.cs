using System;

namespace ELSAPI.Entities
{
    public class BasketItem
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string PictureUrl { get; set; }
        public string ColorName { get; set; }
        public string SizeName { get; set; }
        public AppUser AppUser { get; set; }
        public string AppUserId { get; set; }
        
    }
}