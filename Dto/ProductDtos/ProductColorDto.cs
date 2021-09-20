using System.Collections.Generic;
using ELSAPI.Entities;

namespace ELSAPI.Dto
{
    public class ProductColorDto
    {
        public string Url { get; set; }
        public string PublicId { get; set; }
        public bool IsMain { get; set; }
        public List<ColorSizeDto> SizeOptions { get; set; }
        public int ColorId { get; set; }
        public Color Color { get; set; }
        public int Quantity { get; set; }
        
    }
}