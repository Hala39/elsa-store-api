using System.Collections.Generic;

namespace ELSAPI.Entities
{
    public class ColorSize
    { 
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public ProductColor ProductColor { get; set; }
        public Size Size { get; set; }
        public int SizeId { get; set; }
        
    }
} 