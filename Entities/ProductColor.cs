using System.Collections.Generic;
using System.Linq;

namespace ELSAPI.Entities
{
    public class ProductColor
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string PublicId { get; set; }
        public bool IsMain { get; set; }
        public List<ColorSize> SizeOptions { get; set; }
        public int ColorId { get; set; }
        public Color Color { get; set; }
        public int ProductId { get; set; }
        public Product product { get; set; }
        public int Quantity => SizeOptions.Sum(s => s.Quantity);

    }
}