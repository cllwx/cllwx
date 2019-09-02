using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cllwx.Models
{
    public class Cart
    {
        public int CustomerId { get; set; }
        public List<Product> Products { get; set; }
    }
}
