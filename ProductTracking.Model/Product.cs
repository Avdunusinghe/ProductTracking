using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductTracking.Model
{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Category { get; set; }
        public decimal Price { get; set; }
        public int Quntity { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
