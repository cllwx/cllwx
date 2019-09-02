using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cllwx.Models
{
    public class SpecialItem
    {
        public List<QuantityItem> Quantities { get; set; }
        public double Total { get; set; }
    }
}
