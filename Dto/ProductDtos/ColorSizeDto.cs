using System.Collections.Generic;
using ELSAPI.Entities;

namespace ELSAPI.Dto
{
    public class ColorSizeDto
    {
        public Size Size { get; set; }
        public int Quantity { get; set; }
        public int ColorId { get; set; }
        public int ProductId { get; set; }
    }
}