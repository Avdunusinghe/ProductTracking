using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductTracking.DTO
{
    public class ProductDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Category { get; set; }
        public decimal Price { get; set; }
        public int Quntity { get; set; }
    }
}
