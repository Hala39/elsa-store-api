using System.Collections.Generic;
using ELSAPI.Entities;

namespace ELSAPI.Dto
{
    public class MiniProductColorDto
    {
        public string Url { get; set; }
        public string IsMain { get; set; }
        public List<ColorSizeDto> SizeOptions { get; set; }
        public Color Color { get; set; }
        public int Quantity { get; set; }
        
    }
}