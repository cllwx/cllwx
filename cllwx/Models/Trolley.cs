using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cllwx.Models
{
    public class Trolley
    {
        public List<ProductItem> Products { get; set; }
        public List<SpecialItem> Specials { get; set; }
        public List<QuantityItem> Quantities { get; set; }
    }
}
